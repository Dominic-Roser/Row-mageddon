using System;
using System.Collections;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Torpedoobj = GameObject.Find("Torpedo");
        torpedoCooldown = 5f;
        currentCooldownTime = 0f;
        Torpedoobj.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        torpedokc = PowerupDisplay.getKeyCodeOfPowerup("Torpedo");
        waterspeed = 5.0f;
        targetPosition = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldownTime -= Time.deltaTime;
        if(!beingShot) { 
            Torpedoobj.transform.position = transform.position;
            Torpedoobj.transform.rotation = transform.rotation;
            if(Input.GetKeyDown(torpedokc) && !isOnCooldown()) {
                currentCooldownTime = torpedoCooldown;
                beingShot = true;
                Torpedoobj.GetComponent<SpriteRenderer>().enabled = true;
                Torpedoobj.transform.position = transform.position + (transform.up * 2.5f);
                targetedEnemy = PowerupDisplay.getClosestEnemy(this.gameObject);
                Debug.Log(targetedEnemy.name);
            }
        // if it has been shot
        } if (beingShot) {
            Torpedoobj.GetComponent<BoxCollider2D>().enabled = true;
            targetPosition = targetedEnemy.transform.position;

            Torpedoobj.transform.position = UnityEngine.Vector2.MoveTowards(Torpedoobj.transform.position, 
            targetPosition, waterspeed * Time.deltaTime);
            if(collided || currentCooldownTime <= 0) {
                // on hit disappear and move back to the boat
                Torpedoobj.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Torpedoobj.transform.position = transform.position;
                collided = false;
                Torpedoobj.GetComponent<BoxCollider2D>().enabled = false;
                currentCooldownTime = torpedoCooldown;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }
}
