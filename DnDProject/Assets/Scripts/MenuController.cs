using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{
    [Header("Levels to Load")]
    public string _newGameLevel;
    private string levelToLoad;
    public string _mapGameLevel;
    public string _oldGameLevel;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);

    }

    public void MapGameDialogYes()
    {
        SceneManager.LoadScene(_mapGameLevel);
    }

    public void NewGameDialogNo()
    {
        //working version
        SceneManager.LoadScene(_oldGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
   


    public void ExitButton()
    {
        Application.Quit();
    }
}
