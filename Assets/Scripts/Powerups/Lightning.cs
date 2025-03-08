using System.Xml.Serialization;
using Unity.Services.Analytics;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float lightningDuration;
    private bool shrunk;
    private float currentTime;
    private KeyCode lightningkc;
    private float currentCooldownTime;
    private float lightingcooldown;
    private GameObject lightingcooldownobj;
    private GameObject[] enemies;
    private float[] enemyLightningSpeeds;


    void Start() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        lightingcooldown = 10.0f;
        currentCooldownTime = lightingcooldown;
        //shrinkMultiplier = 0.08f;
        lightningDuration = 3.5f;
        shrunk = false;
        lightningkc = PowerupDisplay.getKeyCodeOfPowerup("Lightning");
        lightingcooldownobj = PowerupDisplay.getCooldownObject(lightningkc);
        enemyLightningSpeeds = new float[enemies.Length];
        for(int i = 0; i < enemyLightningSpeeds.Length; i++) {
          enemyLightningSpeeds[i] = enemies[i].GetComponent<enemyPath>().defaultSpeed*0.65f;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() {
        if(lightningkc!=KeyCode.None){
            if(isOnCooldown()){
                lightingcooldownobj.SetActive(true);
            } else {
                lightingcooldownobj.SetActive(false);
            }
        }
        if(Input.GetKeyUp(lightningkc) && !shrunk && !isOnCooldown()){
            startLightningTimer();
            currentCooldownTime=0;
            recordLightningEvent(gameObject);
        }
        currentCooldownTime+=Time.deltaTime;
        if(shrunk) {
            for(int i = 0; i < enemies.Length; i++) {
              enemies[i].transform.localScale = new Vector3(0.5f,0.5f,0.5f);
              enemies[i].GetComponent<enemyPath>().CurrentSpeed = enemyLightningSpeeds[i];
            }
            currentTime -= Time.deltaTime;
            // Apply speed boost
            if (currentTime <= 0) {
              Debug.Log("Done with shrinking");
                shrunk = false;
                currentTime = lightningDuration;
                for(int i = 0; i < enemies.Length; i++) {
                  enemies[i].transform.localScale = new Vector3(1,1,1);
                  enemies[i].GetComponent<enemyPath>().CurrentSpeed = enemies[i].GetComponent<enemyPath>().defaultSpeed;
                }

            }
        }
    }
    public void startLightningTimer() {
        currentTime = lightningDuration;
        shrunk = true;
    }

    public bool isOnCooldown(){
        return currentCooldownTime<=lightingcooldown;
    }
    public static void recordLightningEvent(GameObject boat) {
        if (AnalyticsData.analyticsActive) {
            PowerupUsageEvent tutorialEndedEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "Lightning",
                chosenLevel = PlayerData.levelToLoad,
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
            Debug.Log("Lightning event logged at time: "+ GameManager.instance.GetRaceTime());
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
    
}
