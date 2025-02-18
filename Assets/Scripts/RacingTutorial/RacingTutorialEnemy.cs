using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RacingTutorialEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array of waypoints to walk from one to the next one
    [SerializeField] private float defaultSpeed = 2f; // Walk speed that can be set in Inspector
    public static float currentSpeed;
    public bool hit;
    private bool isSlowed = false;
    private int waypointIndex = 0; // Index of current waypoint from which Enemy walks to the next one
    private Animator enemyAnimator;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.SetPositionAndRotation(new Vector3(0f, 3.5f, 0f), new Quaternion());
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
        if (!enemyAnimator.enabled && GameManager.instance.GetGameState() == GameStates.running)
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
                ApplyRotation(waypointIndex);
                waypointIndex += 1;
            }
        }
        if (transform.position.x > 120)
        {
            SceneManager.LoadScene("LoseScene");
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

    private void ApplyRotation(int waypointIndex)
    {
        switch (waypointIndex)
        {
            case 0: // At Waypoint 1, rotate counterclockwise 90 degrees
                transform.Rotate(0, 0, 45);
                break;
            case 1: // At Waypoint 2, rotate counterclockwise 90 degrees
                transform.Rotate(0, 0, 45);
                break;
            case 2: // At Waypoint 3, rotate clockwise 45 degrees
                transform.Rotate(0, 0, -45);
                break;
            case 3: // At Waypoint 4, rotate clockwise 45 degrees
                transform.Rotate(0, 0, -45);
                break;
            case 4: // At Waypoint 4, rotate clockwise 45 degrees
                transform.Rotate(0, 0, -45);
                break;
            case 5: // At Waypoint 4, rotate clockwise 45 degrees
                transform.Rotate(0, 0, -45);
                break;
            case 6: // At Waypoint 4, rotate counterclockwise 45 degrees
                transform.Rotate(0, 0, 45);
                break;
            case 7: // At Waypoint 4, rotate counterclockwise 45 degrees
                transform.Rotate(0, 0, 45);
                break;
     
        }
    }

    // Disables movement and animation
    private void DisableEnemy()
    {
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
        if (enemyAnimator != null)
        {
            enemyAnimator.enabled = true;
        }
    }
}
