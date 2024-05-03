using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public TMP_Text line1Text; // Reference to the TMP_Text component for line 1
    public TMP_Text line2Text; // Reference to the TMP_Text component for line 2
    public TMP_Text line3Text; // Reference to the TMP_Text component for line 3
    private string action = ""; // String to store the current action
    private string target = ""; // String to store the current target
    private float moveDistance = 0f; // Float to store the move distance
    private Queue<string> historyQueue = new Queue<string>(); // Queue to store history actions

    // Range indicator GameObjects
    public GameObject longswordRange;
    public GameObject shortbowRange;

    // UI target GameObjects
    public GameObject goblinTarget;
    public GameObject GoblinToken;

    private void Start()
    {
        // Hide range indicators initially
        longswordRange.SetActive(false);
        shortbowRange.SetActive(false);
    }

    public void SetAction(string newAction)
    {
        action = newAction; // Set the current action

        // Show range indicator based on the selected action
        switch (action)
        {
            case "Longsword":
                ShowMeleeRange();
                //if (!IsGoblinInRange()) DisableGoblinTarget();
                break;
            case "Short Bow":
                ShowRangedRange();
                //if (!IsGoblinInRange()) DisableGoblinTarget();
                break;
            default:
                HideRangeIndicators();
                break;
        }
    }

    //  private bool IsGoblinInRange()
    // {

    //     // private void OnTriggerEnter2D(Collider2D collision) {
    //     // if(collision.gameObject.name == "GoblinToken") 
    //     // {
    //     //     Debug.Log("TEST");
    //     // }
    //     //}


    //     // Determine which range indicator to use based on the selected action
    //     GameObject rangeIndicator;
    //     if (action == "Longsword")
    //     {
    //         rangeIndicator = longswordRange;
    //     }
    //     else if (action == "Short Bow")
    //     {
    //         rangeIndicator = shortbowRange;
    //     }
    //     else
    //     {
    //         return false; // No valid action selected
    //     }

    //     // Ensure the goblin token has a collider attached
    //     CircleCollider2D goblinCollider = GoblinToken.GetComponent<CircleCollider2D>();
    //     if (goblinCollider == null)
    //     {
    //         Debug.LogWarning("Goblin collider not found!");
    //         return false;
    //     }

    //     // Get the bounds of the range indicator
    //     Bounds rangeBounds = rangeIndicator.GetComponent<BoxCollider2D>().bounds;

    //     // Check for overlap between the range indicator and the goblin collider
    //     bool overlap = Physics2D.OverlapCircle(rangeBounds.center, rangeBounds.extents.x, goblinCollider.gameObject.layer);

    //     if (overlap)
    //     {
    //         Debug.Log("The goblin is in range!");
    //     }

    //     return overlap;
    // }

    // private void DisableGoblinTarget()
    // {
    //     // Disable the UI element representing the goblin target
    //     goblinTarget.SetActive(false);
    // }

    private void ShowMeleeRange()
    {
        longswordRange.SetActive(true);
        shortbowRange.SetActive(false);
    }

    private void ShowRangedRange()
    {
        longswordRange.SetActive(false);
        shortbowRange.SetActive(true);
    }

    private void HideRangeIndicators()
    {
        longswordRange.SetActive(false);
        shortbowRange.SetActive(false);
    }

    public void SetTarget(string newTarget)
    {
        target = newTarget; // Set the current target
    }

    public void SetMoveDistance(float distance)
    {
        moveDistance = distance; // Set the move distance
    }

    public void ConfirmAction()
    {
        //You used <color=#E1A521>Melee</color> on <color="red">Goblin</color>

        string actionString = "";

        if (action == "move")
        {
            actionString = "You moved <color=#E1A521>" + moveDistance.ToString("F1") + "</color>m";
        }
        else if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(target))
        {
            actionString = "You used <color=#E1A521>" + action + "</color> on <color=\"red\">" + target + "</color>";
        }

        if (!string.IsNullOrEmpty(actionString))
        {
            // Output the action to the history
            AddToHistory(actionString);

            // Reset action, target, and moveDistance
            action = "";
            target = "";
            moveDistance = 0f;
        }
    }

    private void AddToHistory(string action)
    {
        historyQueue.Enqueue(action); // Add action to the history queue
        UpdateHistoryPanel();
    }

    private void UpdateHistoryPanel()
    {
        // Update TMP Text components with history actions from the queue
        line1Text.text = historyQueue.Count > 0 ? historyQueue.ToArray()[historyQueue.Count - 1] : "";
        line2Text.text = historyQueue.Count > 1 ? historyQueue.ToArray()[historyQueue.Count - 2] : "";
        line3Text.text = historyQueue.Count > 2 ? historyQueue.ToArray()[historyQueue.Count - 3] : "";
    }

    public void ClearHistory()
    {
        historyQueue.Clear(); // Clear the history queue
        UpdateHistoryPanel(); // Update the history panel text lines
    }
}

