using UnityEngine;

public class EnemyUseWatergun : MonoBehaviour
{
    private GameObject EnemyBeer;
    private GameObject Player;
    public static bool collided;
    public static bool beingShot = false;
    private float shotDuration;
    private Vector3 beerDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() {
        beingShot = true;
        shotDuration = 0f;
        EnemyBeer = GameObject.Find("EnemyBeer");
        Player = GameObject.Find("Boat");
        EnemyBeer.transform.position = transform.position;
        EnemyBeer.transform.rotation = transform.rotation;
        EnemyBeer.GetComponent<SpriteRenderer>().enabled = true;
        EnemyBeer.GetComponent<BoxCollider2D>().enabled = true;
        beerDirection = (Player.transform.position - EnemyBeer.transform.position).normalized;
    }

    // Update is called once per frame
    void Update() {
        if (beingShot) {
            shotDuration += Time.deltaTime;
            EnemyBeer.transform.Translate(beerDirection*0.1f, Space.World);
            //on a hit, hide and come back
            if(collided || shotDuration > 5f) {
                // on hit disappear and move back to the boat
                EnemyBeer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                EnemyBeer.transform.position = transform.position;
                collided = false;
                EnemyBeer.GetComponent<BoxCollider2D>().enabled = false;
                this.enabled = false;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
}
