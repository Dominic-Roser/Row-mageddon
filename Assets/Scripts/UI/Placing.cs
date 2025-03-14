using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class Placing : MonoBehaviour
{
    private Dictionary<RaceProgressTracker, float> boatProgress = new Dictionary<RaceProgressTracker, float>();
    private RaceProgressTracker[] boats;
    private TextMeshProUGUI positionText;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Boat");
        positionText = GetComponent<TextMeshProUGUI>();

        if (positionText == null)
        {
            Debug.LogError("Placing: No TMP found on this GameObject");
            return;
        }

        boats = FindObjectsByType<RaceProgressTracker>(FindObjectsSortMode.None);
    }

    void Update()
    {
        boatProgress.Clear();
        foreach (var boat in boats)
        {
            boatProgress[boat] = boat.RaceDistance; //  Use distance instead of progress percentage
        }

        var sortedBoats = boatProgress.OrderByDescending(b => b.Value).ToList();
        if (PlayerData.levelToLoad == "Level6" || PlayerData.levelToLoad == "Level8") {
            int position = player.GetComponent<RaceProgressTracker5678>().playerplace;
            positionText.text =  GetOrdinal(position);
        } else {
            int position = sortedBoats.FindIndex(b => b.Key.gameObject.name == "Boat") + 1;
            if (LevelData.TotalLaps[PlayerData.levelToLoad]!=1) {
                if(PlayerData.lapscompleted>GameObject.Find("EnemyBoat1").GetComponent<EnemyData>().lapscompleted
                        && PlayerData.lapscompleted>GameObject.Find("EnemyBoat2").GetComponent<EnemyData>().lapscompleted){
                    positionText.text = GetOrdinal(1);
                } else if (PlayerData.lapscompleted<GameObject.Find("EnemyBoat1").GetComponent<EnemyData>().lapscompleted
                        && PlayerData.lapscompleted<GameObject.Find("EnemyBoat2").GetComponent<EnemyData>().lapscompleted) {
                    positionText.text = GetOrdinal(3);

                } else {
                    positionText.text = GetOrdinal(position);
                }
            } else {
                positionText.text = GetOrdinal(position);
            }

            RaceProgressTracker playerBoat = boats.FirstOrDefault(b => b.gameObject.name == "Boat");
            float playerDistance = playerBoat.RaceDistance;

            foreach (var entry in sortedBoats)
            {
                RaceProgressTracker enemyBoat = entry.Key;
                if (enemyBoat.gameObject.name == "Boat") continue;

                float enemyDistance = entry.Value;
                float distanceDifference = Mathf.Abs(enemyDistance - playerDistance);

                /*
                Debug.Log($"{enemyBoat.gameObject.name} is {Mathf.Abs(distanceDifference):F2} meters " +
                        $"{(distanceDifference > 0 ? "ahead" : "behind")} the player.");
                */
                // Only do speed adjustment if the speed difference is greater than 20m
                if (distanceDifference > 20f)
                {
                    enemyBoat.GetComponent<enemyPath>().AdjustSpeedBasedOnPosition(playerDistance, enemyDistance);
                }
                else if (enemyBoat.GetComponent<enemyPath>().IsSpeedAdjusted)
                {
                    Debug.Log("Enemy boat speed has been reset");
                    enemyBoat.GetComponent<enemyPath>().ResetSpeed();
                }
            }
        }
    }

    private string GetOrdinal(int number)
    {
        if (number == 1) return number + "st";
        if (number == 2) return number + "nd";
        if (number == 3) return number + "rd";
        return number + "th";
    }
}
