using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    // for collision
    private Vector2 SELF_EXTENTS;

    // movement control
    public float SPEED = 10.0f;
    private Vector2 _velocity = Vector2.zero;
    public bool willMove = false;
    public double moveSpeed = 6;
    public Image movementRange;


    // pathfinding
    private MapManager _mmap;
    private List<Vector2> _path;
    private Vector2 _waypoint;

    // Start is called before the first frame update
    void Start()
    {
        // extents is the half width/height of the sprite in world units
        SELF_EXTENTS = (Vector3)transform.GetComponent<SpriteRenderer>().sprite.bounds.extents;

        _mmap = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    void Update()
    {
        movementRange.rectTransform.localScale = new Vector3((float)(moveSpeed*2), (float)(moveSpeed*2), 1);
        // on click, call the pathfinding system to generate a new path from the agent to that location
        if (Input.GetMouseButtonDown(0) && willMove) {
            Debug.Log("transform: "+transform.position[0]);
            Debug.Log("mouse: "+ Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            double x = Math.Pow(transform.position[0]- Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 2);
            double y = Math.Pow(transform.position[1] - Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 2);
            
            double distance = Math.Sqrt(x + y);
            Debug.Log("distance: " + distance);
            distance = Math.Round(distance / .7,MidpointRounding.AwayFromZero);
            
            
            // note optional last argument is to turn on visual debugging
            // *** don't uncomment this until you start fixing the path search! it will infinite loop if you accidentally click ***
            if (moveSpeed - distance >= 0)
            {
                if (moveSpeed != 0)
                {
                    _path = _mmap.getPath(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), true);
                    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    if(_path != null)
                    {
                        moveSpeed -= distance;
                    }
                    
                    movementRange.gameObject.SetActive(false);
                    Debug.Log("moveSpeed:  " + moveSpeed);
                }
            }
            willMove = false;

        }
        
        // if the path is not null, move to the first waypoint in the path (just like back in lab01)
        if(_path != null && _path.Count > 0)
        {
            
            // if you reach the first waypoint during this frame, remove it from the path
            // (keep in mind to check and move directly to the waypoint to avoid stepping past it)
            _waypoint = _path[0]; // get first waypoint
            Vector2 direction = (_waypoint - (Vector2)transform.position).normalized; //calc the direction
            transform.Translate(direction * SPEED * Time.deltaTime); //move towards waypoint
            if (Vector2.Distance(transform.position, _waypoint) < 0.1f) // if agent is close to waypoint, remove it from path
            {
                _path.RemoveAt(0);
            }
        }
        // after moving, use the code below to fix any overlap with the blocking wall tiles

        // check collision with the wall tiles to avoid cutting corners
        Vector2 overlapResponse = _mmap.checkBlockedCollision(transform.position, SELF_EXTENTS);
        // use the overlapResponse vector to move yourself out of walls (it will be (0,0) if no overlap detected)
        transform.position = transform.position + (Vector3)overlapResponse;

    }
    public void resetMovement()
    {
        moveSpeed = 6;
    }
}
