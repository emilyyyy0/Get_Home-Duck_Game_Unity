using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void TriggerInstruction()
    {
        SceneManager.LoadScene(4);
    }

    public void InstructionsNext()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Prev(){
        SceneManager.LoadScene(4);
    }
}