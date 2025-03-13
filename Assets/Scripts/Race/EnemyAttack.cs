
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour{
  private int enemyNum;

  void Start() {
    enemyNum = getThisEnemyNumber();
    }
  public void UseFishingRod() {
    Debug.Log("enemy used fishingrod");
    GetComponent<EnemyUseFishingRod>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }
  public void UseBeer() {
    Debug.Log("enemy used beer");
    GetComponent<EnemyUseBeer>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public void UseTorpedo() {
    Debug.Log("enemy used torpedo");
    GetComponent<EnemyUseTorpedo>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public void UseWaterGun() {
    Debug.Log("enemy used watergun");
    GetComponent<EnemyUseWaterGun>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public void UseSpeedBoost() {
    Debug.Log("enemy used speedboost");
    GetComponent<EnemyUseSpeedBoost>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public int getThisEnemyNumber () {
      int num = int.Parse(gameObject.name[gameObject.name.Length-1].ToString());
      return num;
    }
}