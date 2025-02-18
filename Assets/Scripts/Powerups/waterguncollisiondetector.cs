using System.Collections;
using UnityEngine;

public class waterguncollisiondetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBoat")
        {
            watergun.collided = true;
            BlowEnemyAway();
        }
    }

    private void BlowEnemyAway() {
        float originalSpeed = enemyPath.currentSpeed;
        enemyPath.currentSpeed = originalSpeed; // Restore original speed
    }
}
