using Unity.Services.Analytics;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    private float whirlpoolCooldown = 10f;
    private float currentCooldownTime;
    private KeyCode whirlpoolkc;
    public GameObject whirlpoolCooldownAnimationObj;

    void Start()
    {
        whirlpoolkc = PowerupDisplay.getKeyCodeOfPowerup("Whirlpool");
        whirlpoolCooldownAnimationObj = PowerupDisplay.getCooldownObject(whirlpoolkc);
    }

    void Update()
    {
        if (whirlpoolkc != KeyCode.None) {
            whirlpoolCooldownAnimationObj.SetActive(isOnCooldown());
        }

        currentCooldownTime -= Time.deltaTime;

        if (Input.GetKeyDown(whirlpoolkc) && !isOnCooldown()) {
            SpawnWhirlpool();
            currentCooldownTime = whirlpoolCooldown;
        }
    }

    private void SpawnWhirlpool()
    {
        Vector3 spawnPosition = transform.position + (transform.right * -2.5f);
        //spawnPosition+=new Vector3(0, 0, 0.29f);

        GameObject newWhirlpool = new GameObject("Whirlpool");
        newWhirlpool.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        newWhirlpool.transform.position = spawnPosition;

        SpriteRenderer sr = newWhirlpool.AddComponent<SpriteRenderer>();
        sr.sprite = PlayerData.powerupIconDictionary["Whirlpool"];
        sr.sortingOrder = 0;
        sr.sortingLayerName = "Game objects";

        BoxCollider2D collider = newWhirlpool.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        newWhirlpool.AddComponent<WhirlpoolCollisionDetector>();

        recordWhirlpoolEvent(gameObject);

        Destroy(newWhirlpool, 20f);
    }

    public bool isOnCooldown()
    {
        return currentCooldownTime > 0;
    }

    public static void recordWhirlpoolEvent(GameObject boat)
    {
        if (AnalyticsData.analyticsActive)
        {
            PowerupUsageEvent whirlpoolEvent = new PowerupUsageEvent
            {
                x = boat.transform.position.x,
                y = boat.transform.position.y,
                z = boat.transform.position.z,
                powerup = "Whirlpool",
                chosenLevel = PlayerData.levelToLoad,
                timeInLevel = GameManager.instance.GetRaceTime()
            };

            Debug.Log("Whirlpool event logged at time: " + GameManager.instance.GetRaceTime());
            AnalyticsService.Instance.RecordEvent(whirlpoolEvent);
        }
        else
        {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
