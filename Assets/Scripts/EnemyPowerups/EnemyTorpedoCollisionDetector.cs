using System.Collections;
using UnityEngine;

public class EnemyTorpedoCollisionDetector : MonoBehaviour
{

    void Awake() {
        transform.position = new Vector3 (-100f, -100f, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Boat")
        {
            EnemyUseTorpedo.collided = true;
            StartCoroutine(SlowPlayerForSeconds(1f));
        }
    }

    private IEnumerator SlowPlayerForSeconds(float duration) {
        float originalSpeed = PlayerData.speed;
        PlayerData.speed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        PlayerData.speed = originalSpeed; // Restore original speed
    }
}
