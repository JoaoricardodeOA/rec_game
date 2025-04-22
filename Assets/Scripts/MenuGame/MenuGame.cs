using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void PlayGame(){
        PlayerPrefs.SetInt("LevelCompleted", 0 );
        SceneManager.LoadScene("MapScene");
    }
}
