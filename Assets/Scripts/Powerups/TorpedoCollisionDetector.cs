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
            StartCoroutine(SlowEnemyForSeconds(1f));
        }
    }

    private IEnumerator SlowEnemyForSeconds(float duration) {
        float originalSpeed = enemyPath.currentSpeed;
        enemyPath.currentSpeed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        enemyPath.currentSpeed = originalSpeed; // Restore original speed
    }
}
