using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int playerLevel = 4; // the player's level - represented by the most recent level they have unlocked
    public static string[] SelectedPowerupNames = new string[4]; // the names of the selected powerups
    public static List<string> UnlockedPowerupNames = new List<string> {"FishingRod", "Torpedo"}; // the names of the unlocked powerups always starts out with the fishing rod 
    public static float speed = 2f; // the players current speed from the boat
    public static float defaultSpeed = 2f;
    public static float maxSpeed = 6f; // the player's max speed from the boat
    public static float defaultMaxSpeed = 6f;
    public static float minSpeed = 2f; // the player's max speed from the boat
    public static float boostAmount = 2f; // the amount the player boosts from hitting in the green
    public static float greenZonePercent = 0.3f; // the percentage of the meter that the green zone takes up
    public static float turnSpeed = 100f; // the speed at which the player turns
    public static string boatName; // the name of the boat
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
    public static int gold = 100;
    public static bool gamePaused = false;

    public static Dictionary<string, int> levelNewCompletionGoldRewards = new Dictionary<string, int>{
        {"newRacing", 5},
        {"Level1", 5},
        {"Level2", 5},
        {"Level3", 5},
        {"Level4", 10},
        {"Level5", 10},
        {"Level6", 10},
        {"Level7", 15},
        {"Level8", 15},
        {"Level9", 15},
        {"Level10", 20},
    };
    public static Dictionary<string, int> levelStaleCompletionGoldRewards = new Dictionary<string, int>{
        {"newRacing", 1},
        {"Level1", 2},
        {"Level2", 2},
        {"Level3", 2},
        {"Level4", 4},
        {"Level5", 4},
        {"Level6", 4},
        {"Level7", 8},
        {"Level8", 8},
        {"Level9", 8},
        {"Level10", 12},
    };












}
