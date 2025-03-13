using System;
using Unity.VisualScripting;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private GameObject activeForceField;
    public bool ffActive;
    public float ffDuration;
    public float currentDuration;
    private float ffCooldown;
    private float currentCooldownTime;
    private KeyCode ffkc;
    private GameObject ffcooldownobject;
    private Vector3 holdpos;

    private Sprite ffsprite;

    void Start()
    {
        ffCooldown = 10f;
        currentCooldownTime = 0f;
        ffDuration = 2f;
        currentDuration = 0f;
        ffActive = false;
        ffsprite = Resources.Load<Sprite>("TinsleyPieces/ForceField");
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
                SpawnFF();

                activeForceField.transform.position = transform.position;
                activeForceField.transform.rotation = transform.rotation; // Match the boat's rotation

                // Set the sprite opacity to 50% (half opacity)
                SpriteRenderer sr = activeForceField.GetComponent<SpriteRenderer>();
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
            activeForceField.transform.position = transform.position;

            activeForceField.transform.rotation = transform.rotation; // Match the boat's rotation

            if (currentDuration <= 0)
            {
                Destroy(activeForceField);
                activeForceField.GetComponent<SpriteRenderer>().enabled = false;
                ffActive = false;
                PlayerData.forcefieldActive = false;
            }
        }
    }


    private void SpawnFF()
    {
        Vector3 spawnPosition = transform.position;

        activeForceField = new GameObject("ForceField");
        activeForceField.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        activeForceField.transform.position = spawnPosition;
        activeForceField.transform.rotation = transform.rotation;

        SpriteRenderer sr = activeForceField.AddComponent<SpriteRenderer>();
        sr.sprite = ffsprite;
        sr.sortingOrder = 1;
        sr.sortingLayerName = "Game objects";

        //recordreflectEvent(gameObject);
    }

    public bool isOnCooldown()
    {
        return currentCooldownTime > 0;
    }
}

