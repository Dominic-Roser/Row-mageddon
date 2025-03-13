using System;
using Unity.VisualScripting;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private GameObject Forcefield;
    public bool ffActive;
    public float ffDuration;
    public float currentDuration;
    private float ffCooldown;
    private float currentCooldownTime;
    private KeyCode ffkc;
    private GameObject ffcooldownobject;
    private Vector3 holdpos;

    void Start()
    {
        Forcefield = GameObject.Find("ForceField");
        ffCooldown = 10f;
        currentCooldownTime = 0f;
        ffDuration = 5f;
        currentDuration = 0f;
        Forcefield.GetComponent<SpriteRenderer>().enabled = false;
        ffActive = false;
        ffkc = PowerupDisplay.getKeyCodeOfPowerup("ForceField");
        ffcooldownobject = PowerupDisplay.getCooldownObject(ffkc);
    }

    void Update()
    {
        if (ffkc != KeyCode.None)
        {
            ffcooldownobject.SetActive(isOnCooldown());
        }

        currentCooldownTime -= Time.deltaTime;
        currentDuration -= Time.deltaTime;

        if (!ffActive)
        {

            if (Input.GetKeyDown(ffkc) && !isOnCooldown())
            {
                Forcefield.GetComponent<SpriteRenderer>().enabled = true;

                Forcefield.transform.position = transform.position - (transform.up * 1.7f);
                Forcefield.transform.rotation = transform.rotation; // Match the boat's rotation

                // Set the sprite opacity to 50% (half opacity)
                SpriteRenderer sr = Forcefield.GetComponent<SpriteRenderer>();
                Color color = sr.color;
                color.a = 0.5f; // 50% opacity
                sr.color = color;

                currentCooldownTime = ffCooldown;
                ffActive = true;
                currentDuration = ffDuration;
                PlayerData.forcefieldActive = true;
            }
        }

        if (ffActive)
        {
            // Update the forcefield's position to follow the boat during active state
            Forcefield.transform.position = transform.position - (transform.up * 1.001f);

            Forcefield.transform.rotation = transform.rotation; // Match the boat's rotation

            if (currentCooldownTime <= 0)
            {
                Forcefield.GetComponent<SpriteRenderer>().enabled = false;
                ffActive = false;
                PlayerData.forcefieldActive = false;
            }
        }
    }

    public bool isOnCooldown()
    {
        return currentCooldownTime > 0;
    }
}

