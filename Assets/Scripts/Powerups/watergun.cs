using UnityEngine;

public class watergun : MonoBehaviour
{
    private GameObject WaterGun;
    public bool beingShot;
    public static bool collided;
    private float WaterGunCooldown;
    private GameObject nearestEnemy;
    private float currentCooldownTime;
    private KeyCode WaterGunkc;
    public GameObject WaterGunCooldownAnimationObj;
    private bool holdingDown;
    private bool forwards;
    private float speedDir;
    private Vector3 holdpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaterGun = GameObject.Find("WaterGun");
        WaterGunCooldown = 5f;
        WaterGun.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        WaterGunkc = PowerupDisplay.getKeyCodeOfPowerup("WaterGun");
        WaterGunCooldownAnimationObj = PowerupDisplay.getCooldownObject(WaterGunkc);

    }

    // Update is called once per frame
    void Update()
    {
        if(WaterGunkc != KeyCode.None) {
            if(isOnCooldown()){
                WaterGunCooldownAnimationObj.SetActive(true);
            } else {
                WaterGunCooldownAnimationObj.SetActive(false);
            }
        }
        currentCooldownTime -= Time.deltaTime;
        // if it hasen't been shot yet
        if(!beingShot) { 
            if(Input.GetKeyDown(WaterGunkc) && !isOnCooldown()) {
                speedDir = 0.15f;
                holdingDown = true;
                WaterGun.GetComponent<SpriteRenderer>().enabled = true;
                WaterGun.transform.position = transform.position + (transform.up * 2.5f);
                holdpos = transform.position + (transform.up * 2.5f);
            } else if (Input.GetKeyUp(WaterGunkc) && !isOnCooldown()) {
                currentCooldownTime = WaterGunCooldown;
                beingShot = true;
                holdingDown = false;
            } 
            if(!beingShot){
                if(!holdingDown){
                    holdpos = transform.position + (transform.right * 2.5f);
                    WaterGun.transform.position = holdpos;
                    WaterGun.transform.rotation = transform.rotation;
                } else if (holdingDown && forwards) {
                    holdpos = transform.position + (transform.right * 2.5f);
                    speedDir = 0.15f;
                    WaterGun.transform.position = holdpos;
                } else if (holdingDown && !forwards) {
                    holdpos = transform.position + (transform.right * -2.5f);
                    speedDir = -0.15f;
                    WaterGun.transform.position = holdpos;
                }

                if (Input.GetKeyDown(KeyCode.W)) {
                    forwards = true;
                } else if(Input.GetKeyDown(KeyCode.S)){
                    forwards = false;
                }
            }
        } 
        // if it has been shot
        if (beingShot) {
            WaterGun.GetComponent<BoxCollider2D>().enabled = true;
            WaterGun.transform.Translate(new Vector3(speedDir, 0f, 0f));
            //on a hit, hide and come back
            if(currentCooldownTime<=0) {
                // on hit disappear and move back to the boat
                WaterGun.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                WaterGun.transform.position = transform.position;
                collided = false;
                WaterGun.GetComponent<BoxCollider2D>().enabled = false;
                //currentCooldownTime = WaterGunCooldown;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }

}
