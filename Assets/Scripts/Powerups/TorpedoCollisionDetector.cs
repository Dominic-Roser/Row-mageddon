using UnityEngine;

public class TorpedoCollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Torpedo.collided = true;
            enemyPath.currentSpeed /=2.0f;
        }
    }
}
