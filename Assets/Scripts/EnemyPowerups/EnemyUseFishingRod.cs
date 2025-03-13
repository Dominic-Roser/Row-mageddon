using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUseFishingRod : MonoBehaviour
{
    private GameObject closestEnemy;
    private float reelSpeed;
    public bool enemyInRange;
    private UnityEngine.Vector3 pullLocation;
    private float pullTimer;
    private float maxPullTime = 4f;
    void OnEnable() {
      // closestEnemy = PowerupDisplay.getClosestEnemy(this.gameObject); TODO change this to make it so that the enemy can find other enemies or players
      
      closestEnemy = GameObject.Find("Boat"); // placeholder
      reelSpeed = 6.8f;
      pullLocation = getClosestSide(closestEnemy);
      enemyInRange = (closestEnemy.transform.position - transform.position).sqrMagnitude < 154f;
      pullTimer = 0f; // Reset timer on enable

    }
    // Update is called once per frame
    void Update()
    {
      if (PlayerData.forcefieldActive)
      {
        pullTimer = maxPullTime;
      }

      if (enemyInRange) {
        closestEnemy.GetComponent<NewMovement>().enabled = false;
        closestEnemy.transform.position = UnityEngine.Vector2.MoveTowards(closestEnemy.transform.position, 
        pullLocation, reelSpeed * Time.deltaTime);

        pullTimer += Time.deltaTime;

        if (closestEnemy.transform.position == pullLocation || pullTimer >= maxPullTime) {
          closestEnemy.GetComponent<NewMovement>().enabled = true;
          this.enabled = false;
        }
      } else {
        this.enabled = false;
      }
    }

    public UnityEngine.Vector3 getClosestSide(GameObject Enemy) {
      UnityEngine.Vector3 portSnapLocation = transform.position + (2.5f*transform.up); 
      UnityEngine.Vector3 starboardSnapLocation = transform.position - (2.5f*transform.up); 
      float distanceToPort = (Enemy.transform.position - portSnapLocation).sqrMagnitude;
      float distanceToStarboard = (Enemy.transform.position - starboardSnapLocation).sqrMagnitude;

      if (distanceToPort < distanceToStarboard) {
        return portSnapLocation;
      } else {
        return starboardSnapLocation;
      }
    }
}
