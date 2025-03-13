using System.Collections;
using UnityEngine;

public class EnemyWaterGunCollisionDetector : MonoBehaviour
{
    private bool reflected;
    private GameObject enemyAttacker;

    void OnEnable()
    {
        reflected = false;
        enemyAttacker = GameObject.Find("EnemyBoat" + gameObject.name[gameObject.name.Length-1]);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Boat" && !PlayerData.forcefieldActive)
        {
            enemyAttacker.GetComponent<EnemyUseWaterGun>().collided = true;
            BlowPlayerAway(other.gameObject);
        } else if (other.gameObject.name == "Boat" && PlayerData.forcefieldActive) {
            Debug.Log("shielded from water");
            enemyAttacker.GetComponent<EnemyUseWaterGun>().collided = true;
        }
        else if(!reflected && other.gameObject.name == "Reflect") {
            GameObject returnEnemy = enemyAttacker;
            returnEnemy.GetComponent<EnemyUseWaterGun>().beerDirection *= -1f;
            reflected = true;

            Collider2D torpedoCollider = GetComponent<Collider2D>();
            torpedoCollider.enabled = false;
            StartCoroutine(ReenableCollider(torpedoCollider));
        }
        if (reflected && other.gameObject.name == enemyAttacker.name){
            enemyAttacker.GetComponent<EnemyUseBeer>().collided = true;
            enabled = false;
            reflected = false;
            BlowPlayerAway(enemyAttacker);
            //StartCoroutine(SlowEnemyForSeconds(enemyAttacker, 2f));
        }
    }

    private void BlowPlayerAway(GameObject player) {
    //Vector2 currentDirection = (enemy.targetWaypoint.position - enemyPath.transform.position).normalized;
    Vector2 pushDirection = transform.up.normalized; // Direction of water stream

    // Blend current direction with push direction
    //Vector2 newDirection = (currentDirection + pushDirection).normalized;
    Vector2 newDirection = pushDirection.normalized;

    // Override enemy direction for a short time
    StartCoroutine(OverridePlayerDirection(player, newDirection, 1.5f)); // Push for 1.5 seconds
}

    private IEnumerator OverridePlayerDirection(GameObject player, Vector2 newDirection, float duration) {
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

    private IEnumerator ReenableCollider(Collider2D collider) {
        yield return null; // Wait one frame
        collider.enabled = true;
    }
}
