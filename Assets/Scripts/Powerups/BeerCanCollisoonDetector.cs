using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BeerCanCollisionDetector : MonoBehaviour
{
    void Awake() {
        gameObject.transform. localScale = new Vector3(1.8f, 1.8f, 1.8f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2,2);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BeerController.collided = true;
            StartCoroutine(SlowEnemyForSeconds(other.gameObject, 5f));
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
