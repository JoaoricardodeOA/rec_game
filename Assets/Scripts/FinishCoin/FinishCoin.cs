using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishCoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("LevelCompleted", 1); 

            SceneManager.LoadScene("MapScene");

        }
    }
}
