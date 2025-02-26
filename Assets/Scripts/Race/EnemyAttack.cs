
using UnityEngine;

public class EnemyAttack : MonoBehaviour{
  static GameObject EnemyBoat;

  void Start() {
    EnemyBoat = GameObject.Find("EnemyBoat");
  }
  public static void UseFishingRod() {
    EnemyBoat.GetComponent<EnemyUseFishingRod>().enabled = true;
    enemyPathlvl5.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used fishingrod");
  }
  public static void UseBeer() {
    EnemyBoat.GetComponent<EnemyUseBeer>().enabled = true;
    enemyPathlvl5.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used beer");
  }

  public static void UseTorpedo() {
    EnemyBoat.GetComponent<EnemyUseTorpedo>().enabled = true;
    enemyPathlvl5.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used torpedo");
  }

  public static void UseWaterGun() {
    EnemyBoat.GetComponent<EnemyUseWaterGun>().enabled = true;
    enemyPathlvl5.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used watergun");
  }

  public static void UseSpeedBoost() {
    EnemyBoat.GetComponent<EnemyUseSpeedBoost>().enabled = true;
    enemyPathlvl5.usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used speedboost");
  }

}