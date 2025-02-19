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
            WaterGun.transform.position = transform.position;
            WaterGun.transform.rotation = transform.rotation;
            if(Input.GetKeyDown(WaterGunkc) && !isOnCooldown()) {
                currentCooldownTime = WaterGunCooldown;
                beingShot = true;
                WaterGun.GetComponent<SpriteRenderer>().enabled = true;
                WaterGun.transform.position = transform.position + (transform.up * 2.5f);
            }
        // if it has been shot
        } if (beingShot) {
            WaterGun.GetComponent<BoxCollider2D>().enabled = true;
            WaterGun.transform.Translate(new Vector3(0f, 0.15f, 0f));
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
