using System.Collections;
using UnityEngine;

public class EnemyUseSpeedBoost : MonoBehaviour {
    private float originalSpeed;
    void OnEnable()
    {
      originalSpeed = gameObject.GetComponent<enemyPath>().CurrentSpeed;
      //Debug.Log("boost with og speed: " + originalSpeed);
      gameObject.GetComponent<enemyPath>().CurrentSpeed += 2f;
      StartCoroutine(ResetSpeedAfterTime(2f));
    }
    IEnumerator ResetSpeedAfterTime(float duration)
    {
      yield return new WaitForSeconds(duration);
      gameObject.GetComponent<enemyPath>().CurrentSpeed = originalSpeed;
      //Debug.Log("done with speed boost now at speed: " + gameObject.GetComponent<enemyPath>().CurrentSpeed);
      this.enabled = false;
    }
}