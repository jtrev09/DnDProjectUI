using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnedBasedSystem : MonoBehaviour
{
    /*
        playerTurnA is referring to player selecting an action 
        playerTurnB is referring to player selecting a enemy after 
        selecting a action.  
    */
    public enum States { setUp, playerTurnA, playerTurnB, EndPhase, enemyTurn, won, lose }
    public States state;
    public TextMeshProUGUI actionSeq;
    public GameObject playerUI;
    //public PointerHover selectScript; 

    //public ActionTest actionSelected; 
    public string btnName;
    bool pressedBackBtn = false;
    //public PlayerUnit Player; 
    void Start()
    {
        //backBtn.enabled = false; 
        state = States.setUp;
        //actionSelected = GetComponent<ActionTest>(); 

        StartCoroutine(Setup());
    }


    IEnumerator Setup()
    {
        state = States.setUp;
        yield return new WaitForSeconds(3f);
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1f);
        state = States.playerTurnA;
    }

    IEnumerator EnemyAction(int n)
    {
        /*switch(n){
            case 0:
                actionSeq.text = "Enemy uses Bleep Blop";
                yield return new WaitForSeconds(1f);

                if(Player.debuff == "DefenceDown" && npc.buff == "PowerUp"){
                    Player.curHealth = 0;actionSeq.text = "You take BIG damage";}
                else if(Player.debuff == "DefenceDown" || npc.buff == "PowerUp"){
                    Player.curHealth -= 12;actionSeq.text = "You take 12 damage";}
                else{
                    // regular attack 
                    actionSeq.text = "You take 9 damage";
                    Player.curHealth -= 9;
                }
                yield return new WaitForSeconds(2f);
                break; 
            case 1: 
                actionSeq.text = "Enemy uses Fiber Optics";
                yield return new WaitForSeconds(1f);
                actionSeq.text = "Player defence is down...";
                Player.debuff = "DefenceDown";
                yield return new WaitForSeconds(2f);
                break; 
            case 2:
                actionSeq.text = "Enemy uses Systems Scan";
                yield return new WaitForSeconds(1f);
                actionSeq.text = "Enemy attack power has gone up!";
                npc.buff = "PowerUp";
                yield return new WaitForSeconds(2f);
                break; 
            case 3:
                actionSeq.text = "Enemy gazes at flower";
                yield return new WaitForSeconds(1f);
                actionSeq.text = "Nothing happens... ";
                yield return new WaitForSeconds(2f);
                break; 
            default:
                // someting went wrong 
                break; 
        }
        selectScript.GetSet = null;
        StartCoroutine(PlayerTurn());
         */
        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        state = States.enemyTurn;
        //backBtn.enabled = false;
        playerUI.SetActive(false);
        yield return new WaitForSeconds(3f);
        playerUI.SetActive(true);
        //int rnd = UnityEngine.Random.Range(0,3); 
        //StartCoroutine(EnemyAction(rnd));

    }
    public void passTurn()
    {
        StartCoroutine(EnemyTurn());
    }

    IEnumerator ActionCommence()
    {
        if (btnName == "Punch")
        {

            yield return new WaitForSeconds(3f);
        }
        else if (btnName == "Heal")
        {

            yield return new WaitForSeconds(3f);
        }
        else if (btnName == "MultiHit")
        {

            yield return new WaitForSeconds(3f);
        }
        else if (btnName == "Poison")
        {

            yield return new WaitForSeconds(3f);
        }
        else
        {
            //something went wrong

        }



        /*if(npc.curHealth <= 0)
        {
            // player has won
            StartCoroutine(PlayerWin());
        }
        else if(Player.curHealth <= 0){
            // plahyer has lost
            StartCoroutine(PlayerLose());
        }
        else{
            // game is ongoing
            StartCoroutine(EnemyTurn());  
        }*/
    }

    bool EndPhase()
    {
        //if(selectScript.GetSet == null)
        //return false; 
        //if(actionSelected == null)
        //return false; 
        //npc = selectScript.GetSet; 
        //backBtn.enabled = false; 

        StartCoroutine(ActionCommence());
        return true;
    }

    IEnumerator PlayerWin()
    {
        state = States.won;
        //actionSeq.text = "Defeated " + npc; 
        yield return new WaitForSeconds(2f);
        //load previous scene with defeated enemy 

    }


    IEnumerator PlayerLose()
    {
        state = States.lose;
        yield return new WaitForSeconds(3f);
        // load a restart screne or load scene before fighting npc

    }


    public void ButtonPressed(Button _btn)
    {
        if (state != States.playerTurnA)
            return;
        // after btn press have the abort btn reveal itself 
        //backBtn.enabled = true; 
        //btnName = _btn.name; 

        if (btnName == "Heal")
        {
            //actionSelected.ActionHeal(Player);
            //actionSeq.text = "selected: " + btnName; 
            StartCoroutine(EnemyTurn());
        }
        else
        {
            //actionSeq.text = "selected: " + btnName + "\n Select Enemy: ";
            // save btn, deactivate buttons, wait for enemy selection
            state = States.playerTurnB;

        }

    }




    public void BackBtnClick()
    {
        if (state != States.playerTurnB)
            return;
        pressedBackBtn = true;
        //backBtn.enabled = false; 
    }

}
