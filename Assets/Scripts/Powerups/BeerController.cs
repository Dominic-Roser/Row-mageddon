using Unity.Services.Analytics;
using UnityEngine;

public class BeerController : MonoBehaviour
{
    private GameObject Beer;
    public bool beingShot;
    public static bool collided;
    private float beerCooldown;
    private GameObject nearestEnemy;
    private float currentCooldownTime;
    private KeyCode beerkc;
    public GameObject beerCooldownAnimationObj;
    private bool holdingDown;
    private bool forwards;
    private float speedDir;
    private Vector3 holdpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forwards = true;
        speedDir = 0f;
        holdingDown = true;
        Beer = GameObject.Find("Beer");
        beerCooldown = 5f;
        Beer.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        beerkc = PowerupDisplay.getKeyCodeOfPowerup("Beer");
        beerCooldownAnimationObj = PowerupDisplay.getCooldownObject(beerkc);
    }

    // Update is called once per frame
    void Update()
    {
        if(beerkc != KeyCode.None) {
            if(isOnCooldown()){
                beerCooldownAnimationObj.SetActive(true);
            } else {
                beerCooldownAnimationObj.SetActive(false);
            }
        }
        currentCooldownTime -= Time.deltaTime;
        // if it hasen't been shot yet
        if(!beingShot) { 
            if(Input.GetKeyDown(beerkc) && !isOnCooldown()) {
                speedDir = 0.19f;
                holdingDown = true;
                Beer.GetComponent<SpriteRenderer>().enabled = true;
                holdpos = transform.position + (transform.right * 2.5f);
                Beer.transform.position = holdpos;
            } else if (Input.GetKeyUp(beerkc) && !isOnCooldown()) {
                currentCooldownTime = beerCooldown;
                beingShot = true;
                holdingDown = false;
                recordBeerEvent(gameObject);
            } 
            if(!beingShot){
                Beer.transform.rotation = transform.rotation;
                if(!holdingDown){
                    holdpos = transform.position + (transform.right * 2.5f);
                    Beer.transform.position = holdpos;
                } else if (holdingDown && forwards) {
                    holdpos = transform.position + (transform.right * 2.5f);
                    speedDir = 0.19f;
                    Beer.transform.position = holdpos;

                } else if (holdingDown && !forwards) {
                    holdpos = transform.position + (transform.right * -2.5f);
                    speedDir = -0.19f;
                    Beer.transform.position = holdpos;
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                    forwards = true;
                } else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
                    forwards = false;
                }
            }
        // if it has been shot
        } if (beingShot) {
            Beer.GetComponent<BoxCollider2D>().enabled = true;
            Beer.transform.Translate(new Vector3(speedDir, 0f, 0f));
            //on a hit, hide and come back
            if(collided || currentCooldownTime<=0) {
                // on hit disappear and move back to the boat
                Beer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Beer.transform.position = transform.position;
                collided = false;
                Beer.GetComponent<BoxCollider2D>().enabled = false;
                forwards = true;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }
    public static void recordBeerEvent(GameObject boat) {
        if (AnalyticsData.analyticsActive) {
            PowerupUsageEvent tutorialEndedEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "Beer",
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            Debug.Log("Beer event logged at time: "+ GameManager.instance.GetRaceTime());
            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }

}
