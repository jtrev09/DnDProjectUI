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
    //public Button shortbowButton;
    //public Button longswordButton;

    //public GameObject goblin;

    public Agent moveThis;
    

    public Button confirmYesButton;
    public Button endButton;

    public bool actiona = true;
    public bool actionb = true;

    public bool choseAction = false;
    public bool choseBAction = false;

    public bool choseLongsword;
    public bool choseShortbow;

    public Image activeAction;
    public Image inactiveAction;
    public Image activeBonusaction;
    public Image inactiveBonusaction;
    public Image health;

    public int size1 = 5;
    public Image range1;


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

        // longswordButton.onClick.AddListener(longswordButton_onClick);
        // shortbowButton.onClick.AddListener(shortbowButton_onClick);

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

            range1.gameObject.SetActive(true);
            

        }

    }

    void confirmYesButton_onClick()
    {
        if (choseAction)
        {
            actiona = false;
            Debug.Log("action: " + actiona);
            MainManager.Instance.player.UseAction();

            // if(longsword)
            // {
            //     //goblin.
            // }
            //MainManager.Instance.player.TakeDamage(10);

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

    public void clickShortbow()
    {
        choseShortbow = true;
    }

    public void clickLongsword()
    {
        choseLongsword = true;
    }

    // void longswordButton_onClick()
    // {
    //     choseLongsword = true;
    // }
    // void shortbowButton_onClick()
    // {
    //     choseShortbow = true;        
    // }


    void endButton_onClick()
    {
        actiona = true;
        actionb = true;
        choseAction = false;
        choseBAction = false;
        choseShortbow = false;
        choseLongsword = false;

        MainManager.Instance.player.ResetPlayerForTurn();

        inactiveAction.gameObject.SetActive(false);
        activeAction.enabled = true;
        inactiveBonusaction.gameObject.SetActive(false);
        activeBonusaction.enabled = true;

        //delete afterwards
        moveThis.moveSpeed = 6;

    }

    
}
