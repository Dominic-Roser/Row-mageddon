using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemyPathlvl5 : MonoBehaviour
{

    
    [SerializeField] private Transform[] waypoints; // Array of waypoints to walk from one to the next one
    [SerializeField] private float defaultSpeed = 2f; // Walk speed that can be set in Inspector
    public static float currentSpeed;
    public bool hit;
    private bool isSlowed = false;
    private int waypointIndex = 0; // Index of current waypoint from which Enemy walks to the next one
    private Animator enemyAnimator;
    private bool enabledAtStart = false;

    // Use this for initialization
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
        hit = false;
        currentSpeed = defaultSpeed;

        enemyAnimator = GetComponent<Animator>();

        // Disable movement and animation if the countdown is active
        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            DisableEnemy();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // If the countdown is active, do nothing
        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            return;
        }

        // Enable enemy movement and animation when the race starts
        //if (!enemyAnimator.enabled && GameManager.instance.GetGameState() == GameStates.running)
        if (!enabledAtStart && GameManager.instance.GetGameState() == GameStates.running)
        {
            EnableEnemy();
        }

        // Move Enemy
        Move();
        if (hit && !isSlowed)
        {
            StartCoroutine(slowDown());
        }

    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            Vector2 direction = (waypoints[waypointIndex].position - transform.position).normalized;
            RotateTowards(direction);
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               currentSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.01f)
            {
                waypointIndex += 1;
                EnemyAttack.usedPowerupAtCheckpoint = false;
            }
        }
        if(waypointIndex >= 1 && !EnemyAttack.usedPowerupAtCheckpoint) { // for testing for now
            //EnemyAttack.UseBeer();
            //EnemyAttack.UseWaterGun();
            EnemyAttack.UseSpeedBoost();
       }
    }

    private IEnumerator slowDown()
    {
        currentSpeed = defaultSpeed / 2;
        isSlowed = true;
        yield return new WaitForSeconds(2f);
        currentSpeed = defaultSpeed;
        hit = false;
        isSlowed = false;
    }

    private void RotateTowards(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Smoothly rotate to the new angle using RotateTowards
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180f * Time.deltaTime); // 360 degrees per second

    }


    // Disables movement and animation
    private void DisableEnemy()
    {

        Debug.Log("Enemy Disabled and speed is: 0");
        currentSpeed = 0;
        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = false;
        }
    }

    // Reenables movement and animation
    private void EnableEnemy()
    {
        currentSpeed = defaultSpeed;
        Debug.Log("Enemy Enabled and speed is now: " + currentSpeed);
        enabledAtStart = true;
        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = true;
        }
    }

}