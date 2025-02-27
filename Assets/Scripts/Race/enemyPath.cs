using UnityEngine;
using System.Collections;
using System.Linq;

public class enemyPath : MonoBehaviour
{
    [SerializeField] private Transform waypointParent; // Parent object containing waypoints as children
    private Transform[] waypoints;
    [SerializeField] private float defaultSpeed = 2f; // Individual default speed
    private float currentSpeed; // Each enemy has its own speed (instance variable)
    public bool hit;
    private bool isSlowed = false;
    private int waypointIndex = 0;
    private Animator enemyAnimator;
    private bool enabledAtStart = false;

    public float CurrentSpeed // Public getter for external access
    {
        get { return currentSpeed; }
        set { currentSpeed = value; }
    }

    private void Start()
    {
        hit = false;
        currentSpeed = defaultSpeed; // Each enemy uses its own speed
        enemyAnimator = GetComponent<Animator>();

        if (waypointParent != null)
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>()
                                      .Where(t => t != waypointParent)
                                      .ToArray();
        }
        else
        {
            Debug.LogError("Waypoint Parent not assigned in " + gameObject.name);
            return;
        }

        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            DisableEnemy();
        }
    }

    private void Update()
    {
        if (GameManager.instance.GetGameState() == GameStates.countDown) return;
        if (!enabledAtStart && GameManager.instance.GetGameState() == GameStates.running) EnableEnemy();

        Move();
        if (hit && !isSlowed) StartCoroutine(slowDown());
    }

    private void Move()
    {
        if (waypoints.Length == 0) return; 

        Vector2 direction = (waypoints[waypointIndex].position - transform.position).normalized;
        RotateTowards(direction);
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].position,
            currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.01f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length) // If last waypoint reached, restart path
            {
                waypointIndex = 0;
            }
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), 180f * Time.deltaTime);
    }

    private void DisableEnemy()
    {
        Debug.Log("Enemy Disabled and speed is: 0");
        currentSpeed = 0;
        if (enemyAnimator != null) enemyAnimator.enabled = false;
    }

    private void EnableEnemy()
    {
        currentSpeed = defaultSpeed;
        Debug.Log("Enemy Enabled and speed is now: " + currentSpeed);
        enabledAtStart = true;
        if (enemyAnimator != null) enemyAnimator.enabled = true;
    }
}
