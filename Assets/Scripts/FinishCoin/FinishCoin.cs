using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;



public class FinishCoin : MonoBehaviour
{
    private int levelUser;
    private int levelGame;

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
            levelUser = PlayerPrefs.GetInt("LevelCompleted", 0);
            levelGame = Int32.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value);
            if (levelUser <= levelGame )
            {
                PlayerPrefs.SetInt("LevelCompleted", levelGame ); 
            }

            SceneManager.LoadScene("MapScene");

        }
    }
}
