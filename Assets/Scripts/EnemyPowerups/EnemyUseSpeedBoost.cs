using System.Collections;
using UnityEngine;

public class EnemyUseSpeedBoost : MonoBehaviour {
    private float originalSpeed;
    private bool usingSpeedBoost;
    void OnEnable()
    {
      if(!usingSpeedBoost) {
        originalSpeed = gameObject.GetComponent<enemyPath>().CurrentSpeed;
        //Debug.Log("boost with og speed: " + originalSpeed);
        gameObject.GetComponent<enemyPath>().CurrentSpeed += 2f;
        StartCoroutine(ResetSpeedAfterTime(2f));
        usingSpeedBoost = true;
      }
    }
    IEnumerator ResetSpeedAfterTime(float duration)
    {
      yield return new WaitForSeconds(duration);
      gameObject.GetComponent<enemyPath>().CurrentSpeed = originalSpeed;
      usingSpeedBoost = false;
      //Debug.Log("done with speed boost now at speed: " + gameObject.GetComponent<enemyPath>().CurrentSpeed);
      this.enabled = false;
    }
}