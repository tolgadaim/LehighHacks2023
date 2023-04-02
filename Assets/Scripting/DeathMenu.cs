using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void RestartGame()
    {
        GameObject.FindObjectOfType<TimeManager>().ResumeTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
