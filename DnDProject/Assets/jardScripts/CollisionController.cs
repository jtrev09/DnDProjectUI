using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public GameObject goblinTarget;

   private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "GoblinToken") 
        {
            Debug.Log("TEST");
            ActivateGoblinTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.name == "GoblinToken")
        {
            DisableGoblinTarget();
        }
    }

    private void DisableGoblinTarget()
    {
        // Disable the UI element representing the goblin target
        goblinTarget.SetActive(false);
    }

    private void ActivateGoblinTarget()
    {
        // activate the UI element representing the goblin target
        goblinTarget.SetActive(true);
    }
}
