using System.Collections;
using UnityEngine;

public class slowtile : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Enemy") {
        StartCoroutine(SlowEnemyForSeconds(other.gameObject, 1.5f));
        this.gameObject.SetActive(false);
      } else {
        PlayerData.speed /= 2.0f;
        this.gameObject.SetActive(false);
      }
    }
    private IEnumerator SlowEnemyForSeconds(GameObject enemy, float duration) {
        enemyPath enemyScript = enemy.GetComponent<enemyPath>();
        float originalSpeed = enemyScript.CurrentSpeed;
        enemyScript.CurrentSpeed /= 2.0f; // Slow by half
        yield return new WaitForSeconds(duration);
        enemyScript.CurrentSpeed = originalSpeed; // Restore original speed
    }
}