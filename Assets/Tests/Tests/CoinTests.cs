using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTests
{
    

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator LifeCoinPasses()
    {

       var testObject = new GameObject("TriggerObject");
        var triggerCollider = testObject.AddComponent<BoxCollider2D>();
        triggerCollider.isTrigger = true;
        testObject.AddComponent<Rigidbody2D>().isKinematic = true;
        testObject.AddComponent<Lifecoin>();

        var colliderObject = new GameObject("MovingObject");
        colliderObject.AddComponent<PlayerScript>();
        colliderObject.AddComponent<BoxCollider2D>();
        colliderObject.AddComponent<Rigidbody2D>();
        colliderObject.tag = "Player";

        // Criado TextMeshProUGUI 
        var canvas = new GameObject("Canvas");
        canvas.AddComponent<Canvas>();
        var textGO = new GameObject("LifeText");
        textGO.transform.parent = canvas.transform;
        var text = textGO.AddComponent<TextMeshProUGUI>();

        // ✅ text
        colliderObject.GetComponent<PlayerScript>().textLife = text;

        testObject.transform.position = Vector3.zero;
        colliderObject.transform.position = new Vector3(1f, 0f, 0f);

        // Move para trigger
        colliderObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1f, 0f);

        yield return new WaitForSeconds(1f);

        // Verifica destruição
        Assert.IsTrue(testObject == null || testObject.Equals(null));
    }

    [UnityTest]
    public IEnumerator FinishCoinPasses()
    {
        SceneManager.LoadScene("Level1Scene");

        var testObject = new GameObject("TriggerObject");
        var triggerCollider = testObject.AddComponent<BoxCollider2D>();
        triggerCollider.isTrigger = true;
        testObject.AddComponent<Rigidbody2D>().isKinematic = true;
        testObject.AddComponent<FinishCoin>();

        GameObject colliderObject = new GameObject("MovingObject");
        colliderObject.AddComponent<PlayerScript>();
        colliderObject.AddComponent<BoxCollider2D>();
        colliderObject.AddComponent<Rigidbody2D>();
        colliderObject.tag = "Player";
        int levelUser;
        int levelGame;
        PlayerPrefs.SetInt("LevelCompleted", 0);
        levelUser = PlayerPrefs.GetInt("LevelCompleted", 0);


        testObject.transform.position = Vector3.zero;
        colliderObject.transform.position = new Vector3(1f, 0f, 0f);

        colliderObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1f, 0f);

        

        yield return new WaitForSeconds(1f);
        levelGame = PlayerPrefs.GetInt("LevelCompleted", 0);

        // Verifica destruição
        Assert.IsTrue(testObject == null);
        Object.Destroy(colliderObject);
    }
}
