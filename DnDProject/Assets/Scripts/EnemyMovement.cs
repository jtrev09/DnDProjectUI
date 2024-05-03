using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    // for collision
    private Vector2 SELF_EXTENTS;

    // movement control
    public float SPEED = 10.0f;
    private Vector2 _velocity = Vector2.zero;
    public Vector2 targetPosition;
    public GameObject target;
    private bool canHit = true;
    
    public double moveSpeed = 6;

    

    // pathfinding
    private MapManager _mmap;
    private List<Vector2> _path;
    private Vector2 _waypoint;
    // Start is called before the first frame update
    void Start()
    {
        SELF_EXTENTS = (Vector3)transform.GetComponent<SpriteRenderer>().sprite.bounds.extents;

        _mmap = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canHit)
        {
            //attacks player
            TryToHit();
        }
        if (_path != null && _path.Count > 0)
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
    public void TryToHit()
    {
        
        double distance = Vector3.Distance(transform.position, target.transform.position);
        distance = Math.Round(distance / .7, MidpointRounding.AwayFromZero);
        
        if(distance <= 1)
        {
            canHit = false;
            Debug.Log("he is attacking");
            int rnd = UnityEngine.Random.Range(1, 20) + 4;
            if(rnd >= 14)
            {
                Debug.Log(rnd + " hits");
                int dmg = UnityEngine.Random.Range(1, 6) + 2;
                Debug.Log("It deals " + dmg + " damage.");
            }
        }
    }

    public void findSpot()
    {
        moveSpeed = 6;
        canHit = true;
        double distance = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log("This is the distance with vector distance: " + Vector3.Distance(transform.position,target.transform.position));
        
        distance = Math.Round(distance / .7, MidpointRounding.AwayFromZero);
        if(distance <= 7)
        {
            float x = transform.position[0] - target.transform.position[0];
            float y = transform.position[0] - target.transform.position[0];
            targetPosition = (Vector2)target.transform.position;
            if(x < 0)
            {
                targetPosition[0] -= (float).7;
                _path = _mmap.getPath(transform.position, targetPosition, true);
                if(_path == null)
                {
                    if(y < 0)
                    {
                        targetPosition[1] -= (float).7;
                        _path = _mmap.getPath(transform.position, targetPosition, true);
                    }
                    if(_path == null)
                    {
                        targetPosition[1] += (float)1.4;
                        _path = _mmap.getPath(transform.position, targetPosition, true);
                    }
                }
                
            }
            targetPosition = (Vector2)target.transform.position;
            targetPosition[1] += (float).7;
            if (_path == null)
            {
                if(y>0)
                {
                    _path = _mmap.getPath(transform.position, targetPosition, true);
                }
                if(_path == null)
                {
                    targetPosition[1] -= (float)1.4;
                    _path = _mmap.getPath(transform.position, targetPosition, true);
                }
                targetPosition[0] += (float).7;
                if(_path == null)
                {
                    _path = _mmap.getPath(transform.position, targetPosition, true);
                }
                if(_path == null)
                {
                    targetPosition[1] += (float).7;
                    _path = _mmap.getPath(transform.position, targetPosition, true);
                }
                if(_path == null)
                {
                    targetPosition[1] += (float).7;
                    _path = _mmap.getPath(transform.position, targetPosition, true);
                }
            }
        }

    }
}
