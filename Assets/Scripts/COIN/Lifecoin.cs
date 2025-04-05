using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lifecoin : MonoBehaviour
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
            collision.GetComponent<PlayerScript>().life++;
            Destroy(this.gameObject);
        }
    }
}
