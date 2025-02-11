using UnityEngine;

public class BeerCanCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBoat")
        {
            BeerController.collided = true;
            enemyPath.currentSpeed /=2.0f;
        }
    }
}
