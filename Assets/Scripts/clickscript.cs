using UnityEngine;
using UnityEngine.SceneManagement;


public class clickscript : MonoBehaviour
{
    private bool enable;
    private int level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string objectTag = gameObject.tag;
        level = int.Parse(objectTag.Substring(5));
        Renderer renderer = GetComponent<Renderer>();
        Debug.Log(PlayerPrefs.GetInt("LevelCompleted", 0));
        if (PlayerPrefs.GetInt("LevelCompleted", 0) + 1 >= level)
        {
            enable = true;
            renderer.material.color = Color.green;

        }
        else
        {
            enable = false;
            renderer.material.color = Color.white;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if(enable){
            Debug.Log("clicked");
            SceneManager.LoadScene("Level"+level+"Scene");
        }
        
    }
}
