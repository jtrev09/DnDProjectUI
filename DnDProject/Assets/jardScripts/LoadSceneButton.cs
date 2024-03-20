using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneName = "mapSelection"; // Name of the scene to load

    // Method to be called when the button is pressed
    public void LoadMapSelectionScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
