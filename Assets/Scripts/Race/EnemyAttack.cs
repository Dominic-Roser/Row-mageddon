
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour{
  static GameObject EnemyBoat;
  private int enemyNum;

  void Start() {
    enemyNum = getThisEnemyNumber();
    EnemyBoat = GameObject.Find("EnemyBoat" + enemyNum);
  }
  public static void UseFishingRod() {
    Debug.Log("enemy used fishingrod");
    EnemyBoat.GetComponent<EnemyUseFishingRod>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }
  public static void UseBeer() {
    Debug.Log("enemy used beer");
    EnemyBoat.GetComponent<EnemyUseBeer>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public static void UseTorpedo() {
    Debug.Log("enemy used torpedo");
    EnemyBoat.GetComponent<EnemyUseTorpedo>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public static void UseWaterGun() {
    Debug.Log("enemy used watergun");
    EnemyBoat.GetComponent<EnemyUseWaterGun>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public static void UseSpeedBoost() {
    Debug.Log("enemy used speedboost");
    EnemyBoat.GetComponent<EnemyUseSpeedBoost>().enabled = true;
    enemyPath.usedPowerupAtCheckpoint = true;
  }

  public int getThisEnemyNumber () {
      int num = int.Parse(gameObject.name[gameObject.name.Length-1].ToString());
      Debug.Log("enemy name is: " + num);
      return num;
    }
}