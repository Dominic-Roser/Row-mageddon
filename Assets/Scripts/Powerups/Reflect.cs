using Unity.Services.Analytics;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    private float reflectCooldown = 10f;
    private float currentCooldownTime;
    private KeyCode reflectkc;
    public GameObject reflectCooldownAnimationObj;
    private Sprite reflectsprite;
    private bool reflectOn;
    private GameObject activeReflect; // Store the reference to the spawned reflect object

    void Start()
    {
        reflectOn = false;
        reflectsprite = Resources.Load<Sprite>("Materials/reflectenim");
        reflectkc = PowerupDisplay.getKeyCodeOfPowerup("Reflect");
        reflectCooldownAnimationObj = PowerupDisplay.getCooldownObject(reflectkc);
    }

    void Update()
    {
        if (reflectkc != KeyCode.None)
        {
            reflectCooldownAnimationObj.SetActive(isOnCooldown());
        }

        currentCooldownTime -= Time.deltaTime;

        if (Input.GetKeyDown(reflectkc) && !isOnCooldown())
        {
            Spawnreflect();
            currentCooldownTime = reflectCooldown;
        }

        // Move and rotate reflect if it's active
        if (reflectOn && activeReflect != null)
        {
          activeReflect.transform.position = transform.position + (transform.right * 2.5f);
          activeReflect.transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z+180);
        }
    }

    private void Spawnreflect()
    {
        reflectOn = true;
        Vector3 spawnPosition = transform.position + (transform.right * 2.5f);

        activeReflect = new GameObject("Reflect");
        activeReflect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        activeReflect.transform.position = spawnPosition;
        activeReflect.transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z+180);

        SpriteRenderer sr = activeReflect.AddComponent<SpriteRenderer>();
        sr.sprite = reflectsprite;
        sr.sortingOrder = 0;
        sr.sortingLayerName = "Game objects";

        BoxCollider2D collider = activeReflect.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        activeReflect.AddComponent<Rigidbody2D>();

        recordreflectEvent(gameObject);

        // Destroy reflect after 1 second
        StartCoroutine(DestroyReflectAfterTime(100f));
    }

    private System.Collections.IEnumerator DestroyReflectAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(activeReflect);
        reflectOn = false;
    }

    public bool isOnCooldown()
    {
        return currentCooldownTime > 0;
    }

    public static void recordreflectEvent(GameObject boat)
    {
        if (AnalyticsData.analyticsActive)
        {
            PowerupUsageEvent reflectEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "Reflect",
                chosenLevel = PlayerData.levelToLoad,
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            Debug.Log("reflect event logged at time: " + GameManager.instance.GetRaceTime());
            AnalyticsService.Instance.RecordEvent(reflectEvent);
        }
        else
        {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
