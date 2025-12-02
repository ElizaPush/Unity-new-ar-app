using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    

    public void ClickButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
