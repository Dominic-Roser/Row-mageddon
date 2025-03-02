using Unity.Services.Analytics;
using Unity.VisualScripting;
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
        closestEnemy = FindNearestEnemy(transform.position); // placeholder
        reelSpeed = 6.5f;
        enemyInRange = false;

        fishingrodkc = PowerupDisplay.getKeyCodeOfPowerup("FishingRod");
        currentCooldownTime = fishingrodcooldown;
        fishingrodcooldownobj = PowerupDisplay.getCooldownObject(fishingrodkc);

    }

    // Update is called once per frame
    void Update()
    {
        if (fishingrodkc != KeyCode.None)
        {
            fishingrodcooldownobj.SetActive(isOnCooldown());
        }

        closestEnemy = FindNearestEnemy(transform.position); // Dynamically update the closest enemy

        if (closestEnemy != null)
        {
            enemyInRange = (closestEnemy.transform.position - transform.position).sqrMagnitude < 144f;
        }
        else
        {
            enemyInRange = false;
        }

        if (Input.GetKeyDown(fishingrodkc) && !usingFishingRod && enemyInRange && !isOnCooldown()) {
            usingFishingRod = true;
            pullLocation = getClosestSide(closestEnemy);
            currentCooldownTime = 0;
            recordFishingEvent(gameObject);
        }
        currentCooldownTime += Time.deltaTime; 

        if (usingFishingRod && closestEnemy != null) {
            closestEnemy.GetComponent<enemyPath>().enabled = false;
            closestEnemy.transform.position = UnityEngine.Vector2.MoveTowards(closestEnemy.transform.position, 
            pullLocation, reelSpeed * Time.deltaTime);

            if (closestEnemy.transform.position == pullLocation) {
                
                usingFishingRod = false;
                closestEnemy.GetComponent<enemyPath>().enabled = true;
            }
        }
    }

    private GameObject FindNearestEnemy(Vector3 position)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
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
    public static void recordFishingEvent(GameObject boat) {
        if (AnalyticsData.analyticsActive) {
            PowerupUsageEvent tutorialEndedEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "FishingRod",
                timeInLevel = 0f
            };
            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
            Debug.Log("Fishing rod event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }


}
