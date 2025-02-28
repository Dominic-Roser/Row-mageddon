using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUseTorpedo : MonoBehaviour
{
    private GameObject EnemyTorpedoObj;
    public static bool collided;
    private GameObject targetedEnemy;
    private float waterspeed;
    private Vector3 targetPosition;
    private float shotDuration;
    private int enemyNum;


    void OnEnable() {
      enemyNum = getThisEnemyNumber();
      EnemyTorpedoObj = GameObject.Find("EnemyTorpedo"+enemyNum);
      EnemyTorpedoObj.GetComponent<SpriteRenderer>().enabled = false;
      shotDuration = 0f;
      waterspeed = 11.0f;
      targetPosition = Vector3.zero;
      EnemyTorpedoObj.GetComponent<SpriteRenderer>().enabled = true;
      EnemyTorpedoObj.transform.position = transform.position + (transform.right * 2.5f);
      targetedEnemy = GameObject.Find("Boat"); // TODO change this so it targets other enemies too
      Debug.Log(targetedEnemy.name);
    }

    void Update() {
      shotDuration += Time.deltaTime;
      EnemyTorpedoObj.GetComponent<BoxCollider2D>().enabled = true;
      targetPosition = targetedEnemy.transform.position;

      // Calculate the direction and rotate the torpedo accordingly.
      Vector2 direction = targetPosition - EnemyTorpedoObj.transform.position;
      RotateTowards(direction);

      // Move the torpedo toward the target.
      EnemyTorpedoObj.transform.position = Vector2.MoveTowards(
        EnemyTorpedoObj.transform.position, targetPosition, waterspeed * Time.deltaTime);

      if (collided || shotDuration > 5f)
      {
        // Reset the torpedo on hit or timeout.
        EnemyTorpedoObj.GetComponent<SpriteRenderer>().enabled = false;
        EnemyTorpedoObj.transform.position = transform.position;
        collided = false;
        EnemyTorpedoObj.GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
      }
    }

    private void RotateTowards(Vector2 direction)
    {
      // Calculate the angle for the direction vector.
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
      // Smoothly rotate the torpedo towards the target rotation.
      EnemyTorpedoObj.transform.rotation = Quaternion.RotateTowards(
        EnemyTorpedoObj.transform.rotation, targetRotation, 180f * Time.deltaTime);
    }
    public int getThisEnemyNumber () {
      int num = int.Parse(gameObject.name[gameObject.name.Length-1].ToString());
      Debug.Log("enemy name is: " + num);
      return num;
    }
}
