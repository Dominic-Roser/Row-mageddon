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
        Debug.Log("you have a forcefield");
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
                holdpos = transform.position + (transform.right * 2.5f);
                Forcefield.transform.position = holdpos;
                currentCooldownTime = ffCooldown;
                ffActive = true;
                currentDuration = ffDuration;
                PlayerData.forcefieldActive = true;
                Debug.Log("You cannot be hit");
            }
        }

        if (ffActive)
        {

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
