using Unity.Services.Analytics;
using UnityEngine;

public class SideCannon : MonoBehaviour
{
    private GameObject BowBall;
    public bool beingShot;
    public static bool collided;
    private float sidecannonCooldown;
    private GameObject nearestEnemy;
    private float currentCooldownTime;
    private KeyCode sidecannonkc;
    public GameObject sidecannonCooldownAnimationObj;
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
        BowBall = GameObject.Find("BowBall");
        sidecannonCooldown = 8f;
        BowBall.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        sidecannonkc = PowerupDisplay.getKeyCodeOfPowerup("SideCannon");
        sidecannonCooldownAnimationObj = PowerupDisplay.getCooldownObject(sidecannonkc);
    }

    // Update is called once per frame
    void Update()
    {
        if(sidecannonkc != KeyCode.None) {
            if(isOnCooldown()){
                sidecannonCooldownAnimationObj.SetActive(true);
            } else {
                sidecannonCooldownAnimationObj.SetActive(false);
            }
        }
        currentCooldownTime -= Time.deltaTime;
        // if it hasen't been shot yet
        if(!beingShot) { 
            if(Input.GetKeyDown(sidecannonkc) && !isOnCooldown()) {
                speedDir = 0.27f;
                holdingDown = true;
                BowBall.GetComponent<SpriteRenderer>().enabled = true;
                holdpos = transform.position + (transform.up * 2.5f);
                BowBall.transform.position = holdpos;
            } else if (Input.GetKeyUp(sidecannonkc) && !isOnCooldown()) {
                currentCooldownTime = sidecannonCooldown;
                beingShot = true;
                holdingDown = false;
                recordSideCannonEvent(gameObject);
            } 
            if(!beingShot){
                BowBall.transform.rotation = transform.rotation;
                if(!holdingDown){
                    holdpos = transform.position + (transform.up * 2.5f);
                    BowBall.transform.position = holdpos;
                } else if (holdingDown && forwards) {
                    holdpos = transform.position + (transform.up * 2.5f);
                    speedDir = 0.27f;
                    BowBall.transform.position = holdpos;

                } else if (holdingDown && !forwards) {
                    holdpos = transform.position + (transform.up * -2.5f);
                    speedDir = -0.27f;
                    BowBall.transform.position = holdpos;
                }

                if (!forwards && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
                    forwards = true;
                } else if(forwards && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))){
                    forwards = false;
                }
            }
        // if it has been shot
        } if (beingShot) {
            BowBall.GetComponent<BoxCollider2D>().enabled = true;
            BowBall.transform.Translate(new Vector3(0f, speedDir, 0f));
            //on a hit, hide and come back
            if(collided || currentCooldownTime<=0) {
                // on hit disappear and move back to the boat
                BowBall.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                BowBall.transform.position = transform.position;
                collided = false;
                BowBall.GetComponent<BoxCollider2D>().enabled = false;
                forwards = true;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }
    public static void recordSideCannonEvent(GameObject boat) {
        if (AnalyticsData.analyticsActive) {
            PowerupUsageEvent tutorialEndedEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "SideCannon",
                chosenLevel = PlayerData.levelToLoad,
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            Debug.Log("SideCannon event logged at time: "+ GameManager.instance.GetRaceTime());
            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }

}
