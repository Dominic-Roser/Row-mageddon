
using UnityEngine;

public class EnemyAttack : MonoBehaviour{
  static GameObject EnemyBoat;

  void Start() {
    EnemyBoat = GameObject.Find("EnemyBoat");
  }
  public static void UseFishingRod() {
    EnemyBoat.GetComponent<EnemyUseFishingRod>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used fishingrod");
  }
  public static void UseBeer() {
    EnemyBoat.GetComponent<EnemyUseBeer>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used beer");
  }

  public static void UseTorpedo() {
    EnemyBoat.GetComponent<EnemyUseTorpedo>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used torpedo");
  }

  public static void UseWaterGun() {
    EnemyBoat.GetComponent<EnemyUseWaterGun>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used watergun");
  }

  public static void UseSpeedBoost() {
    EnemyBoat.GetComponent<EnemyUseSpeedBoost>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used speedboost");
  }

}