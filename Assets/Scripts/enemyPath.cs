using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemyPath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float defaultSpeed = 2f;
    private float currentSpeed;
    public bool hit;
    private bool isSlowed = false;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.SetPositionAndRotation(new Vector3(-9.5f, 4.5f, 0f), new Quaternion());
        hit = false;
        currentSpeed = defaultSpeed;
    }

    // Update is called once per frame
    private void Update()
    {

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
        if (transform.position.x > 47.5)
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
        }
    }

}