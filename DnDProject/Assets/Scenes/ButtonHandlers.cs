using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlers : MonoBehaviour
{
    public Button attackButton;
    public Button spellButton;
    public Button itemButton;
    public Button moveButton;
    public GameObject atkPopup;
    public GameObject spellPopup;
    public GameObject itemPopup;
    public GameObject moveMap;

    public Agent moveThis;
    

    public Button confirmYesButton;
    public Button endButton;

    public bool actiona = true;
    public bool actionb = true;

    public bool choseAction = false;
    public bool choseBAction = false;

    public Image activeAction;
    public Image inactiveAction;
    public Image activeBonusaction;
    public Image inactiveBonusaction;
    public Image health;
    public float hp = 100;
    public float maxhp = 100;

    void Update()
    {
        health.fillAmount = (float)MainManager.Instance.player.GetCurrentHp() / (float)MainManager.Instance.player.GetMaxHp();
        
        
    }
    


    void Awake()
    {
        attackButton.onClick.AddListener(attackButton_onClick); //subscribe to the onClick event
        spellButton.onClick.AddListener(spellButton_onClick);
        itemButton.onClick.AddListener(itemButton_onClick);
        moveButton.onClick.AddListener(moveButton_onClick);

        confirmYesButton.onClick.AddListener(confirmYesButton_onClick);
        endButton.onClick.AddListener(endButton_onClick);

    }

    //Handle the onClick event
    void attackButton_onClick()
    {
        if(MainManager.Instance.player.GetIsActionAvailable())
        {
            Debug.Log("atk button");
            choseAction = true;
            atkPopup.SetActive(true);
        }
        
    }
    void spellButton_onClick()
    {
        if (MainManager.Instance.player.GetIsActionAvailable())
        {
            Debug.Log("spell button");
            choseAction = true;
            spellPopup.SetActive(true);
        }

    }
    void itemButton_onClick()
    {
        if (MainManager.Instance.player.GetIsBonusActionAvailable())
        {
            Debug.Log("item button");
            choseBAction = true;
            itemPopup.SetActive(true);
        }

    }
    void moveButton_onClick()
    {
        if (true)
        {
            Debug.Log("move button");
            
            
            moveThis.willMove = true;
            
        }

    }

    void confirmYesButton_onClick()
    {
        if (choseAction)
        {
            actiona = false;
            Debug.Log("action: " + actiona);
            MainManager.Instance.player.UseAction();

            MainManager.Instance.player.TakeDamage(10);

            inactiveAction.gameObject.SetActive(true);
            activeAction.enabled = false;
        }
        else if(choseBAction)
        {
            actionb = false;
            Debug.Log("bonus action: " + actionb);
            MainManager.Instance.player.UseBonusAction();
            inactiveBonusaction.gameObject.SetActive(true);
            activeBonusaction.enabled = false;
        }
        choseAction = false;
        choseBAction = false;

        
        

    }

    void endButton_onClick()
    {
        actiona = true;
        actionb = true;
        choseAction = false;
        choseBAction = false;

        MainManager.Instance.player.ResetPlayerForTurn();

        inactiveAction.gameObject.SetActive(false);
        activeAction.enabled = true;
        inactiveBonusaction.gameObject.SetActive(false);
        activeBonusaction.enabled = true;

        //delete afterwards
        moveThis.moveSpeed = 6;

    }
}
