using System.Xml.Serialization;
using UnityEditor.ShaderGraph.Internal;
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
        speedboostcooldown = 8.0f;
        currentCooldownTime = speedboostcooldown;
        boostMultiplier = 0.01f;
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
        }
        currentCooldownTime+=Time.deltaTime;
        if(speedBoosting) {
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
}
