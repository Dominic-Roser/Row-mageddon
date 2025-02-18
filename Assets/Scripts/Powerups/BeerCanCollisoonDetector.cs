using System.Collections;
using UnityEngine;

public class BeerCanCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBoat")
        {
            BeerController.collided = true;
            StartCoroutine(SlowEnemyForSeconds(3f));
        }
    }

    private IEnumerator SlowEnemyForSeconds(float duration) {
        float originalSpeed = enemyPath.currentSpeed;
        enemyPath.currentSpeed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        enemyPath.currentSpeed = originalSpeed; // Restore original speed
    }
}
