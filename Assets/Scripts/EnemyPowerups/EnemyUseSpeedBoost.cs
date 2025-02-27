using System.Collections;
using UnityEngine;

public class EnemyUseSpeedBoost : MonoBehaviour {
    private float originalSpeed;
    void OnEnable()
    {
      originalSpeed = enemyPathlvl5.currentSpeed;
      Debug.Log("boost with og speed: " + originalSpeed);
      enemyPath.currentSpeed += 2f;
      StartCoroutine(ResetSpeedAfterTime(2f));
    }
    IEnumerator ResetSpeedAfterTime(float duration)
    {
      yield return new WaitForSeconds(duration);
      enemyPath.currentSpeed = originalSpeed;
      Debug.Log("done with speed boost now at speed: " + enemyPathlvl5.currentSpeed);
      this.enabled = false;
    }
}