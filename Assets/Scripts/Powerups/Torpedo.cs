using System;
using Unity.VisualScripting;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    private GameObject Torpedoobj;
    public bool beingShot;
    public static bool collided;
    private float torpedoCooldown;
    private GameObject targetedEnemy;
    private float currentCooldownTime;
    private KeyCode torpedokc;
    private float waterspeed;
    private Vector3 targetPosition;
    private GameObject torpedocooldownobject;

    void Start()
    {
        Torpedoobj = GameObject.Find("Torpedo");

        torpedoCooldown = 5f;
        currentCooldownTime = 0f;
        Torpedoobj.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        torpedokc = PowerupDisplay.getKeyCodeOfPowerup("Torpedo");
        waterspeed = 11.0f;
        targetPosition = Vector3.zero;
        torpedocooldownobject = PowerupDisplay.getCooldownObject(torpedokc);
    }

    void Update()
    {
        if (torpedokc != KeyCode.None)
        {
            torpedocooldownobject.SetActive(isOnCooldown());
        }

        currentCooldownTime -= Time.deltaTime;

        if (!beingShot)
        {
            // Keep torpedo attached to the boat.
            Torpedoobj.transform.position = transform.position;

            if (Input.GetKeyDown(torpedokc) && !isOnCooldown())
            {
                currentCooldownTime = torpedoCooldown;
                beingShot = true;
                Torpedoobj.GetComponent<SpriteRenderer>().enabled = true;
                Torpedoobj.transform.position = transform.position + (transform.up * 2.5f);
                targetedEnemy = PowerupDisplay.getClosestEnemy(this.gameObject);
                Debug.Log(targetedEnemy.name);
            }
        }

        if (beingShot)
        {
            Torpedoobj.GetComponent<BoxCollider2D>().enabled = true;
            targetPosition = targetedEnemy.transform.position;

            // Calculate the direction and rotate the torpedo accordingly.
            Vector2 direction = targetPosition - Torpedoobj.transform.position;
            RotateTowards(direction);

            // Move the torpedo toward the target.
            Torpedoobj.transform.position = Vector2.MoveTowards(
                Torpedoobj.transform.position, targetPosition, waterspeed * Time.deltaTime);

            if (collided || currentCooldownTime <= 0)
            {
                // Reset the torpedo on hit or timeout.
                Torpedoobj.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Torpedoobj.transform.position = transform.position;
                collided = false;
                Torpedoobj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void RotateTowards(Vector2 direction)
    {
        // Calculate the angle for the direction vector.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        // Smoothly rotate the torpedo towards the target rotation.
        Torpedoobj.transform.rotation = Quaternion.RotateTowards(
            Torpedoobj.transform.rotation, targetRotation, 180f * Time.deltaTime);
    }

    public bool isOnCooldown()
    {
        return currentCooldownTime > 0;
    }
}
