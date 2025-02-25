using UnityEngine;

public class EnemyUseWaterGun : MonoBehaviour
{
    private GameObject EnemyWaterGun;
    private GameObject Player;
    public static bool collided;
    public static bool beingShot = false;
    private float shotDuration;
    private Vector3 beerDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() {
        beingShot = true;
        shotDuration = 0f;
        EnemyWaterGun = GameObject.Find("EnemyWaterGun");
        Player = GameObject.Find("Boat");
        EnemyWaterGun.transform.position = transform.position;
        EnemyWaterGun.transform.rotation = transform.rotation;
        EnemyWaterGun.GetComponent<SpriteRenderer>().enabled = true;
        EnemyWaterGun.GetComponent<BoxCollider2D>().enabled = true;
        beerDirection = (Player.transform.position - EnemyWaterGun.transform.position).normalized;
    }

    // Update is called once per frame
    void Update() {
        if (beingShot) {
            shotDuration += Time.deltaTime;
            EnemyWaterGun.transform.Translate(beerDirection*0.1f, Space.World);
            //on a hit, hide and come back
            if(collided || shotDuration > 5f) {
                // on hit disappear and move back to the boat
                EnemyWaterGun.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                EnemyWaterGun.transform.position = transform.position;
                collided = false;
                EnemyWaterGun.GetComponent<BoxCollider2D>().enabled = false;
                this.enabled = false;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
}
