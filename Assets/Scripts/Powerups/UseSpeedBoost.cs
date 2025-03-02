using System.Xml.Serialization;
using Unity.Services.Analytics;
using UnityEngine;

public class UseSpeedBoost : MonoBehaviour
{
    private float boostMultiplier;
    public float boostDuration;
    private bool speedBoosting;
    private float currentTime;
    private KeyCode speedkc;
    private float currentCooldownTime;
    private float speedboostcooldown;
    private GameObject speedboostcooldownobj;


    void Start() {
        speedboostcooldown = 10.0f;
        currentCooldownTime = speedboostcooldown;
        boostMultiplier = 0.06f;
        boostDuration = 2.0f;
        speedBoosting = false;
        speedkc = PowerupDisplay.getKeyCodeOfPowerup("SpeedBoost");
        speedboostcooldownobj = PowerupDisplay.getCooldownObject(speedkc);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() {
        if(speedkc!=KeyCode.None){
            if(isOnCooldown()){
                speedboostcooldownobj.SetActive(true);
            } else {
                speedboostcooldownobj.SetActive(false);
            }
        }
        if(Input.GetKeyUp(speedkc) && !speedBoosting && !isOnCooldown()){
            startBoostTimer();
            currentCooldownTime=0;
            recordSpeedBoostEvent(gameObject);
        }
        currentCooldownTime+=Time.deltaTime;
        if(speedBoosting) {
            //Debug.Log("Speed: " + PlayerData.speed);
            currentTime -= Time.deltaTime;
            // Apply speed boost
            if (currentTime <= 0) {
                speedBoosting = false;
                currentTime = boostDuration;

            } else if (currentTime >= boostDuration/2f) {
                PlayerData.speed += boostMultiplier;
                PlayerData.maxSpeed += boostMultiplier;
            } else if (currentTime < boostDuration/2f) {
                PlayerData.speed -= boostMultiplier;
                PlayerData.maxSpeed -= boostMultiplier;
            }
        }
    }
    public void startBoostTimer() {
        currentTime = boostDuration;
        speedBoosting = true;
    }

    public bool isOnCooldown(){
        return currentCooldownTime<=speedboostcooldown;
    }
    public static void recordSpeedBoostEvent(GameObject boat) {
        if (AnalyticsData.analyticsActive) {
            PowerupUsageEvent tutorialEndedEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "SpeedBoost",
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
            Debug.Log("speed boost event logged at time: "+ GameManager.instance.GetRaceTime());
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
    
}
