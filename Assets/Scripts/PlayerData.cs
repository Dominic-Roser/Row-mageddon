using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int playerLevel; // the player's level
    public static string[] SelectedPowerupNames; // the names of the selected powerups
    public static List<string> UnlockedPowerupNames = new List<string> {"FishingRod", "SpeedBoost"}; // the names of the unlocked powerups
    public static float defaultSpeed; // the players default speed from the boat
    public static float maxSpeed; // the player's max speed from the boat
    public static float boostAmount; // the amount the player boosts from hitting in the green
    public static float greenZonePercent; // the percentage of the meter that the green zone takes up
    public static float turnSpeed; // the speed at which the player turns
    public static Dictionary<string, Sprite> powerupIconDictionary = new Dictionary<string, Sprite>{
        {"Torpedo", Resources.Load<Sprite>("Materials/torpedo")},
        {"SpeedBoost", Resources.Load<Sprite>("Materials/PowerUpIcons/speedboost")},
        {"FishingRod", Resources.Load<Sprite>("Materials/PowerUpIcons/fishingrod")},
        {"Beer", Resources.Load<Sprite>("Materials/beer")},
        };
}
