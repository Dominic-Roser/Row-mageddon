using System.Collections;
using UnityEngine;

public class EnemyBeerCanCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Boat" && !PlayerData.forcefieldActive)
        {
            EnemyUseBeer.collided = true;
            StartCoroutine(SlowPlayerForSeconds(3f));
        }
    }

    private IEnumerator SlowPlayerForSeconds(float duration) {
        float originalSpeed = PlayerData.speed;
        PlayerData.speed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        PlayerData.speed = originalSpeed; // Restore original speed
    }
}
