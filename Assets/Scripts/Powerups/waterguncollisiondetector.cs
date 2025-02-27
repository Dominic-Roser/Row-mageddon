using System.Collections;
using UnityEngine;

public class waterguncollisiondetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            watergun.collided = true;
            Debug.Log("water hit the enemy");
            BlowEnemyAway(other.gameObject);
        }
    }

    private void BlowEnemyAway(GameObject enemy) {
    //Vector2 currentDirection = (enemy.targetWaypoint.position - enemyPath.transform.position).normalized;
    Vector2 pushDirection = transform.up.normalized; // Direction of water stream

    // Blend current direction with push direction
    //Vector2 newDirection = (currentDirection + pushDirection).normalized;
    Vector2 newDirection = pushDirection.normalized;

    // Override enemy direction for a short time
    StartCoroutine(OverrideEnemyDirection(enemy, newDirection, 1.5f)); // Push for 1.5 seconds
}

private IEnumerator OverrideEnemyDirection(GameObject enemy, Vector2 newDirection, float duration) {
    float timer = 0f;
        enemyPath enemyScript = enemy.GetComponent<enemyPath>();

        while (timer < duration) {
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position,
            enemy.transform.position + (Vector3)newDirection,
            enemyScript.CurrentSpeed * Time.deltaTime
        );
        timer += Time.deltaTime;
        yield return null;
    }
}
}
