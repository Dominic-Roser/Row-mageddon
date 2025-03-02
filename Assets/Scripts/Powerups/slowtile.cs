using System.Collections;
using UnityEngine;

public class slowtile : MonoBehaviour {
    public GameObject usedBy;
    private float duration = 1.5f;
    private bool beingUsed;

    private float timeUsed = 0f;
    void OnTriggerEnter2D(Collider2D other)
    {
      beingUsed = true;
      usedBy = other.gameObject;
      gameObject.GetComponent<SpriteRenderer>().enabled = false;
      gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
      if(usedBy){
        if (usedBy.tag == "Enemy" && timeUsed <= duration) {
          timeUsed += Time.deltaTime;
          if (beingUsed) {
            usedBy.GetComponent<enemyPath>().CurrentSpeed /= 1.7f;
            beingUsed = false;
          }
          if (timeUsed>duration) {
            usedBy.GetComponent<enemyPath>().CurrentSpeed *= 1.7f;
            gameObject.SetActive(false);
          }
        } else if (usedBy.name == "Boat" && timeUsed <= duration) {
          PlayerData.speed/=2.0f;
          gameObject.SetActive(false);
        }
      }
    }
}