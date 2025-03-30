using UnityEngine;
using UnityEngine.SceneManagement;


public class clickscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("open");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("SampleScene");
    }
}
