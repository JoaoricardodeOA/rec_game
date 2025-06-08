using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;


public class KeeperTests
{


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator KeeperCollisionTest()
    {
        var testObject = new GameObject("TriggerObject");
        var triggerCollider = testObject.AddComponent<CapsuleCollider2D>();
        triggerCollider.isTrigger = true;
        testObject.AddComponent<Rigidbody2D>().isKinematic = true;
        var keeperScript = testObject.AddComponent<keeper>();



        var colliderObject = new GameObject("MovingObject");
        colliderObject.AddComponent<PlayerScript>();
        colliderObject.AddComponent<CapsuleCollider2D>();
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

        GameObject pointA = new GameObject("PointA");
        pointA.transform.position = testObject.transform.position; // example offset

        GameObject pointB = new GameObject("PointB");
        pointB.transform.position = testObject.transform.position;

        // Assign the Transforms to the keeper script
        keeperScript.a = pointA.transform;
        keeperScript.b = pointB.transform;

        colliderObject.transform.position = new Vector3(0f, 1f, 0f); // above the keeper
        colliderObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, -0.1f);

        // Move para trigger
        //colliderObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0f);
        Debug.Log(colliderObject.transform.position);
        Debug.Log(testObject.transform.position);

        yield return new WaitForSeconds(3f);

        // Verifica destruição
        Assert.IsTrue(keeperScript.collidedWithPlayer);
    }
}
