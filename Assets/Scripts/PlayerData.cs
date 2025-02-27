using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // IMPORTANT MAKE SURE playerLevel IS SET TO 0 whem you are done testing
    public static int playerLevel = 5; // the player's level - represented by the most recent level they have unlocked
    public static string[] SelectedPowerupNames = new string[4]; // the names of the selected powerups
    // IMPORTANT MAKE SURE POWERUPS IS SET TO "FishingRod" whem you are done testing
    public static List<string> UnlockedPowerupNames = new List<string> {"FishingRod", "SpeedBoost"}; // the names of the unlocked powerups always starts out with the fishing rod 
    public static float speed = 2f; // the players current speed from the boat
    public static float defaultSpeed = 2f;
    public static float maxSpeed = 6f; // the player's max speed from the boat
    public static float defaultMaxSpeed = 6f;
    public static float minSpeed = 2f; // the player's max speed from the boat
    public static float boostAmount = 2f; // the amount the player boosts from hitting in the green
    public static float greenZonePercent = 0.3f; // the percentage of the meter that the green zone takes up
    public static float turnSpeed = 100f; // the speed at which the player turns
    public static string boatName = ""; // the name of the boat
    public static string levelToLoad = "newRacing"; // the level to load when ready is pressed
    public static Sprite[] selectedPowerupSprites = new Sprite[4];
    public static bool[] selectedVariablesCT = new bool[4];
    public static Dictionary<string, Sprite> powerupIconDictionary = new Dictionary<string, Sprite>{
        {"Torpedo", Resources.Load<Sprite>("Materials/torpedo")},
        {"SpeedBoost", Resources.Load<Sprite>("Materials/PowerUpIcons/speedBoost")},
        {"FishingRod", Resources.Load<Sprite>("Materials/PowerUpIcons/fishingRod")},
        {"Beer", Resources.Load<Sprite>("Materials/PowerUpIcons/beerCan")},
        {"WaterGun", Resources.Load<Sprite>("Materials/PowerUpIcons/waterGun")},
    };
    public static string previousScene = "OverWorld Map";
    public static int gold = 0;
    public static bool gamePaused = false;
    public static int collectedCoins;
    public static int lapscompleted = 0;
    public static bool halfwaycheckpointcrossed = false;
}
