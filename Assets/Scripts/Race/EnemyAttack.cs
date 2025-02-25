
using UnityEngine;

public class EnemyAttack {
  static GameObject EnemyBoat = GameObject.Find("EnemyBoat");
  public static bool usedPowerupAtCheckpoint = false;
  public static void UseFishingRod() {
    EnemyBoat.GetComponent<EnemyUseFishingRod>().enabled = true;
    usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used fishingrod");
  }
  public static void UseBeer() {
    EnemyBoat.GetComponent<EnemyUseBeer>().enabled = true;
    usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used beer");
  }

  public static void UseTorpedo() {
    
  }

  public static void UseWaterGun() {
    EnemyBoat.GetComponent<EnemyUseWaterGun>().enabled = true;
    usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used watergun");
  }

  public static void UseSpeedBoost() {
    EnemyBoat.GetComponent<EnemyUseSpeedBoost>().enabled = true;
    usedPowerupAtCheckpoint = true;
    Debug.Log("enemy used speedboost");
  }

}