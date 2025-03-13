using System.Collections;
using UnityEngine;

public class EnemyBeerCanCollisionDetector : MonoBehaviour
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
            enemyAttacker.GetComponent<EnemyUseBeer>().collided = true;
            StartCoroutine(SlowPlayerForSeconds(3f));
        }
        else if(!reflected && other.gameObject.name == "Reflect") {
            GameObject returnEnemy = enemyAttacker;
            returnEnemy.GetComponent<EnemyUseBeer>().beerDirection *= -1f;
            reflected = true;

            Collider2D torpedoCollider = GetComponent<Collider2D>();
            torpedoCollider.enabled = false;
            StartCoroutine(ReenableCollider(torpedoCollider));
        }
        if (reflected && other.gameObject.name == enemyAttacker.name){
            enemyAttacker.GetComponent<EnemyUseBeer>().collided = true;
            enabled = false;
            reflected = false;
            StartCoroutine(SlowEnemyForSeconds(enemyAttacker, 2f));
        }
    }

    private IEnumerator SlowPlayerForSeconds(float duration) {
        float originalSpeed = PlayerData.speed;
        PlayerData.speed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        PlayerData.speed = originalSpeed; // Restore original speed
    }

    private IEnumerator SlowEnemyForSeconds(GameObject enemy, float duration) {
        enemyPath enemyScript = enemy.GetComponent<enemyPath>();

        float originalSpeed = enemyScript.defaultSpeed;
        enemyScript.CurrentSpeed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        enemyScript.CurrentSpeed = originalSpeed; // Restore original speed
    }

    private IEnumerator ReenableCollider(Collider2D collider) {
        yield return null; // Wait one frame
        collider.enabled = true;
    }
}
