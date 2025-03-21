using UnityEngine;

public class EnemyUseWaterGun : MonoBehaviour
{
    private GameObject EnemyWaterGun;
    private GameObject Player;
    public bool collided;
    public static bool beingShot = false;
    private float shotDuration;
    public Vector3 beerDirection;
    private int enemyNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() {
        enemyNum = getThisEnemyNumber();
        beingShot = true;
        shotDuration = 0f;
        EnemyWaterGun = GameObject.Find("EnemyWaterGun"+enemyNum);
        Player = GameObject.Find("Boat");
        EnemyWaterGun.transform.position = transform.position;
        EnemyWaterGun.transform.rotation = transform.rotation;
        EnemyWaterGun.GetComponent<SpriteRenderer>().enabled = true;
        EnemyWaterGun.GetComponent<EnemyWaterGunCollisionDetector>().enabled = true;
        EnemyWaterGun.GetComponent<BoxCollider2D>().enabled = true;
        beerDirection = (Player.transform.position - EnemyWaterGun.transform.position).normalized;
    }

    // Update is called once per frame
    void Update() {
        if (beingShot) {
            shotDuration += Time.deltaTime;
            EnemyWaterGun.transform.Translate(beerDirection*0.15f, Space.World);
            //on a hit, hide and come back
            if(collided || shotDuration > 5f) {
                // on hit disappear and move back to the boat
                EnemyWaterGun.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                EnemyWaterGun.transform.position = transform.position;
                collided = false;
                EnemyWaterGun.GetComponent<BoxCollider2D>().enabled = false;
                EnemyWaterGun.GetComponent<EnemyWaterGunCollisionDetector>().enabled = false;
                this.enabled = false;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
    public int getThisEnemyNumber () {
      int num = int.Parse(gameObject.name[gameObject.name.Length-1].ToString());
      return num;
    }
}
