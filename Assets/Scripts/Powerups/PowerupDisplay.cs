//using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class PowerupDisplay : MonoBehaviour
{
    private Sprite lockFab;
    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    private GameObject Boat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockFab = Resources.Load<Sprite>("Materials/lock");
        p1 = GameObject.Find("Powerup1");
        p2 = GameObject.Find("Powerup2");
        p3 = GameObject.Find("Powerup3");
        p4 = GameObject.Find("Powerup4");
        Boat = GameObject.Find("Boat");
        // set each of the powerup slots on the hud to the right png
        if (PlayerData.selectedVariablesCT[0]) {
            p1.GetComponent<Image>().sprite = PlayerData.selectedPowerupSprites[0];
            //PlayerData.SelectedPowerupNames[0] = p1.GetComponent<Image>().sprite.name;
        } else { // if it has not been assigned it displays a lock icon
            p1.GetComponent<Image>().sprite = lockFab;
        }

        if (PlayerData.selectedVariablesCT[1]) {
            p2.GetComponent<Image>().sprite = PlayerData.selectedPowerupSprites[1];
            //PlayerData.SelectedPowerupNames[1] = p2.GetComponent<Image>().sprite.name;
        } else {
            p2.GetComponent<Image>().sprite = lockFab;
        }

        if (PlayerData.selectedVariablesCT[2]) {
            p3.GetComponent<Image>().sprite = PlayerData.selectedPowerupSprites[2];
            //PlayerData.SelectedPowerupNames[2] = p3.GetComponent<Image>().sprite.name;
        } else {
            p3.GetComponent<Image>().sprite = lockFab;
        }

        if (PlayerData.selectedVariablesCT[3]) {
            p4.GetComponent<Image>().sprite = PlayerData.selectedPowerupSprites[3];
            //PlayerData.SelectedPowerupNames[3] = p4.GetComponent<Image>().sprite.name;

        } else {
            p4.GetComponent<Image>().sprite = lockFab;
        }
        activateSelectedPowerupScripts();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void activateSelectedPowerupScripts() {
        Boat.GetComponent<FishingRod>().enabled = PlayerData.SelectedPowerupNames.Contains<string>("FishingRod");
        Boat.GetComponent<UseSpeedBoost>().enabled = PlayerData.SelectedPowerupNames.Contains<string>("SpeedBoost");
        Boat.GetComponent<BeerController>().enabled = PlayerData.SelectedPowerupNames.Contains<string>("Beer");
        Boat.GetComponent<Torpedo>().enabled = PlayerData.SelectedPowerupNames.Contains<string>("Torpedo");
        Boat.GetComponent<watergun>().enabled = PlayerData.SelectedPowerupNames.Contains<string>("WaterGun");
    }

    public static KeyCode getKeyCodeOfPowerup(string PowerupName) {
        Debug.Log("The power up name is " + PowerupName);
        Debug.Log("Player data at 0 is " + PlayerData.SelectedPowerupNames[0]);
        if (PlayerData.SelectedPowerupNames[0] == PowerupName) {
            Debug.Log("ASdasjkldh;lasjd");
            return KeyCode.Alpha1;
        } else if (PlayerData.SelectedPowerupNames[1] == PowerupName) {
            return KeyCode.Alpha2;
        } else if (PlayerData.SelectedPowerupNames[2] == PowerupName) {
            return KeyCode.Alpha3;
        } else if (PlayerData.SelectedPowerupNames[3] == PowerupName) {
            return KeyCode.Alpha4;
        } else {
            return KeyCode.None;
        }
    }

    public static GameObject getClosestEnemy (GameObject self) {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float shortestSqrDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float sqrDistance = (self.transform.position - enemy.transform.position).sqrMagnitude;

            if (sqrDistance < shortestSqrDistance)
            {
                shortestSqrDistance = sqrDistance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    public static GameObject getCooldownObject(KeyCode objkeycode) {
        if (objkeycode == KeyCode.Alpha1) {
            return GameObject.Find("UI/Powerups/Powerup1Cooldown");
        } else if (objkeycode == KeyCode.Alpha2) {
            return GameObject.Find("UI/Powerups/Powerup2Cooldown");
        } else if (objkeycode == KeyCode.Alpha3) {
            return GameObject.Find("UI/Powerups/Powerup3Cooldown");
        } else if (objkeycode == KeyCode.Alpha4) {
            return GameObject.Find("UI/Powerups/Powerup4Cooldown");
        } else {
            return null;
        }
    }
}
