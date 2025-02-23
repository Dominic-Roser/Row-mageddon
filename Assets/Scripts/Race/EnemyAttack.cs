
using UnityEngine;

public class EnemyAttack {
  static GameObject EnemyBoat = GameObject.Find("EnemyBoat");
  public static bool usedBeerAtCheckpoint = false;
  public static void UseFishingRod() {

  }
  public static void UseBeer() {
    EnemyBoat.GetComponent<EnemyUseBeer>().enabled = true;
    usedBeerAtCheckpoint = true;
    Debug.Log("enemy used beer");
  }

  public static void UseTorpedo() {
    
  }

  public static void UseWaterGun() {
    
  }

  public static void UseSpeed() {
    
  }

}