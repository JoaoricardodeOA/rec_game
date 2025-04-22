using UnityEngine;

public class ZonaPerna : MonoBehaviour
{
    private PernaCAbeluda enemyScript;

    void Start()
    {
        enemyScript = GetComponentInChildren<PernaCAbeluda>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyScript.SetPlayerInZone(true, other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyScript.SetPlayerInZone(false, null);
        }
    }
}
