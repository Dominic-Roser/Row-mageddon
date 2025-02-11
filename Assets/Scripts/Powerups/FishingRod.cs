using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    private bool usingFishingRod;
    private GameObject closestEnemy;
    private float reelSpeed;
    public bool enemyInRange;
    private UnityEngine.Vector3 pullLocation;
    void Start()
    {
        usingFishingRod = false;
        closestEnemy = GameObject.Find("EnemyBoat"); // placeholder
        reelSpeed = 6.5f;
        enemyInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((closestEnemy.transform.position - transform.position).sqrMagnitude < 121f) {
            enemyInRange = true;
        } else {
            enemyInRange = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && !usingFishingRod && enemyInRange) {
            usingFishingRod = true; 
            closestEnemy = getClosestEnemy();
            pullLocation = getClosestSide(closestEnemy);
        }
        if (usingFishingRod) {
            closestEnemy.transform.position = UnityEngine.Vector2.MoveTowards(closestEnemy.transform.position, 
            pullLocation, reelSpeed * Time.deltaTime);

            if (closestEnemy.transform.position == pullLocation) {
                usingFishingRod = false;
            }
        }
    }

    GameObject getClosestEnemy () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float shortestSqrDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float sqrDistance = (transform.position - enemy.transform.position).sqrMagnitude;

            if (sqrDistance < shortestSqrDistance)
            {
                shortestSqrDistance = sqrDistance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    public UnityEngine.Vector3 getClosestSide(GameObject Enemy) {
        UnityEngine.Vector3 portSnapLocation = transform.position + (2.5f*transform.up); 
        UnityEngine.Vector3 starboardSnapLocation = transform.position - (2.5f*transform.up); 
        float distanceToPort = (Enemy.transform.position - portSnapLocation).sqrMagnitude;
        float distanceToStarboard = (Enemy.transform.position - starboardSnapLocation).sqrMagnitude;

        if(distanceToPort < distanceToStarboard){
            return portSnapLocation;
        } else {
            return starboardSnapLocation;
        }
    }
}
