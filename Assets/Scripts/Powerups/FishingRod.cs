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
    private KeyCode fishingrodkc;
    private float fishingrodcooldown;
    private float currentCooldownTime;
    private GameObject fishingrodcooldownobj;
    void Start()
    {
        fishingrodcooldown = 6f;
        usingFishingRod = false;
        closestEnemy = GameObject.Find("EnemyBoat"); // placeholder
        reelSpeed = 6.5f;
        enemyInRange = false;

        fishingrodkc = PowerupDisplay.getKeyCodeOfPowerup("FishingRod");
        currentCooldownTime = fishingrodcooldown;
        fishingrodcooldownobj = PowerupDisplay.getCooldownObject(fishingrodkc);

    }

    // Update is called once per frame
    void Update()
    {
        if(fishingrodkc!=KeyCode.None){
            if(isOnCooldown()){
                fishingrodcooldownobj.SetActive(true);
            } else {
                fishingrodcooldownobj.SetActive(false);
            }
        }
        if((closestEnemy.transform.position - transform.position).sqrMagnitude < 121f) {
            enemyInRange = true;
        } else {
            enemyInRange = false;
        }
        if (Input.GetKeyDown(fishingrodkc) && !usingFishingRod && enemyInRange && !isOnCooldown()) {
            usingFishingRod = true; 
            closestEnemy = PowerupDisplay.getClosestEnemy(this.gameObject);
            pullLocation = getClosestSide(closestEnemy);
            currentCooldownTime = 0;
        }
        currentCooldownTime += Time.deltaTime; 
        if (usingFishingRod) {
            closestEnemy.transform.position = UnityEngine.Vector2.MoveTowards(closestEnemy.transform.position, 
            pullLocation, reelSpeed * Time.deltaTime);

            if (closestEnemy.transform.position == pullLocation) {
                usingFishingRod = false;
            }
        }
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

    public bool isOnCooldown(){
        return currentCooldownTime<=fishingrodcooldown;
    }
}
