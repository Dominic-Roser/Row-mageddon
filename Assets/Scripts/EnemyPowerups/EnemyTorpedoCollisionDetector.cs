using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyTorpedoCollisionDetector : MonoBehaviour
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
        Debug.Log("I have entered: " + other.gameObject.name + ", I was shot by: " + enemyAttacker.name);
        if (other.gameObject.name == "Boat" && PlayerData.forcefieldActive) {
            Debug.Log("oops no slow");
            enemyAttacker.GetComponent<EnemyUseTorpedo>().collided = true;
        } else if (other.gameObject.name == "Boat")
        {
            enemyAttacker.GetComponent<EnemyUseTorpedo>().collided = true;
            StartCoroutine(SlowPlayerForSeconds(1f));
        } else if(other.gameObject.name == "Reflect") {
            GameObject returnEnemy = enemyAttacker;
            returnEnemy.GetComponent<EnemyUseTorpedo>().targetedEnemy = returnEnemy;
            reflected = true;

            Collider2D torpedoCollider = GetComponent<Collider2D>();
            torpedoCollider.enabled = false;
            StartCoroutine(ReenableCollider(torpedoCollider));
            Debug.Log("collided with reflect, redirecting");
        }

        if (reflected && other.gameObject.name == enemyAttacker.name){
            Debug.Log("reflected and collided with enemy");
            enemyAttacker.GetComponent<EnemyUseTorpedo>().collided = true;
            enabled = false;
            reflected = false;
            StartCoroutine(SlowEnemyForSeconds(enemyAttacker, 2f));
        }
    }

    private IEnumerator SlowPlayerForSeconds(float duration) {
        float originalSpeed = PlayerData.speed;
        PlayerData.speed /= 1.4f; // Slow by half
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
