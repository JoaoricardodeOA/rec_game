using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class DirectionTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LIfeCoinPasses()
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
        colliderObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f);

        yield return new WaitForSeconds(1f);

        // Verifica destruição
        Assert.IsTrue(testObject == null);
    }
}
