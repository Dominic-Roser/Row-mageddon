using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BeerCanCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BeerController.collided = true;
            StartCoroutine(SlowEnemyForSeconds(other.gameObject, 3f));
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
