using System.Collections;
using UnityEngine;

public class TorpedoCollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Torpedo.collided = true;
            StartCoroutine(SlowEnemyForSeconds(other.gameObject, 1f));
        }
    }

    private IEnumerator SlowEnemyForSeconds(GameObject enemy, float duration) {
        enemyPath enemyScript = enemy.GetComponent<enemyPath>();

        float originalSpeed = enemyScript.CurrentSpeed;
        enemyScript.CurrentSpeed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        enemyScript.CurrentSpeed = originalSpeed; // Restore original speed
    }
}
