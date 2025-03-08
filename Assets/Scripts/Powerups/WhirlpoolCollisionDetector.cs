using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolCollisionDetector : MonoBehaviour
{
    private Dictionary<GameObject, float> originalSpeeds = new Dictionary<GameObject, float>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyPath enemyScript = other.GetComponent<enemyPath>();

            if (enemyScript != null)
            {
                if (!originalSpeeds.ContainsKey(other.gameObject))
                {
                    originalSpeeds[other.gameObject] = enemyScript.CurrentSpeed;
                }

                enemyScript.CurrentSpeed *= 0.63f;
                Debug.Log($"{other.name} entered the whirlpool, speed reduced to {enemyScript.CurrentSpeed}");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyPath enemyScript = other.GetComponent<enemyPath>();

            if (enemyScript != null && originalSpeeds.ContainsKey(other.gameObject))
            {
                enemyScript.CurrentSpeed = originalSpeeds[other.gameObject];
                originalSpeeds.Remove(other.gameObject);
                Debug.Log($"{other.name} exited the whirlpool, speed restored to {enemyScript.CurrentSpeed}");
            }
        }
    }
}
