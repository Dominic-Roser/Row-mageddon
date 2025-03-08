using UnityEngine;

public class EnemyUseBeer : MonoBehaviour
{
    private GameObject EnemyBeer;
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
        EnemyBeer = GameObject.Find("EnemyBeer"+enemyNum);
        Player = GameObject.Find("Boat");
        EnemyBeer.transform.position = transform.position;
        EnemyBeer.transform.rotation = transform.rotation;
        EnemyBeer.GetComponent<SpriteRenderer>().enabled = true;
        EnemyBeer.GetComponent<BoxCollider2D>().enabled = true;
        EnemyBeer.GetComponent<EnemyBeerCanCollisionDetector>().enabled = true;
        beerDirection = (Player.transform.position - EnemyBeer.transform.position).normalized;
    }

    // Update is called once per frame
    void Update() {
        if (beingShot) {
            shotDuration += Time.deltaTime;
            EnemyBeer.transform.Translate(beerDirection*0.15f, Space.World);
            //on a hit, hide and come back
            if(collided || shotDuration > 5f) {
                // on hit disappear and move back to the boat
                EnemyBeer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                EnemyBeer.transform.position = transform.position;
                collided = false;
                EnemyBeer.GetComponent<BoxCollider2D>().enabled = false;
                EnemyBeer.GetComponent<EnemyBeerCanCollisionDetector>().enabled = false;
                this.enabled = false;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
    public int getThisEnemyNumber () {
      int num = int.Parse(gameObject.name[gameObject.name.Length-1].ToString());
      Debug.Log("enemy name is: " + num);
      return num;
    }
}
