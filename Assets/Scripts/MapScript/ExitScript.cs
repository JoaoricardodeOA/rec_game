using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
