using System.Collections;
using UnityEngine;

public class EnemyWaterGunCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Boat")
        {
            EmemyUseWaterGun.collided = true;
            Debug.Log("water hit the player");
            BlowEnemyAway(other.gameObject);
        }
    }

    private void BlowEnemyAway(GameObject player) {
    //Vector2 currentDirection = (enemy.targetWaypoint.position - enemyPath.transform.position).normalized;
    Vector2 pushDirection = transform.up.normalized; // Direction of water stream

    // Blend current direction with push direction
    //Vector2 newDirection = (currentDirection + pushDirection).normalized;
    Vector2 newDirection = pushDirection.normalized;

    // Override enemy direction for a short time
    StartCoroutine(OverrideEnemyDirection(player, newDirection, 1.5f)); // Push for 1.5 seconds
}

private IEnumerator OverrideEnemyDirection(GameObject player, Vector2 newDirection, float duration) {
    float timer = 0f;

    while (timer < duration) {
        player.transform.position = Vector2.MoveTowards(
            player.transform.position,
            player.transform.position + (Vector3)newDirection,
            PlayerData.speed * Time.deltaTime
        );
        timer += Time.deltaTime;
        yield return null;
    }
}
}
