using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerData : MonoBehaviour
{
    // IMPORTANT MAKE SURE playerLevel IS SET TO 0 whem you are done testing
    public static int playerLevel = 0; // the player's level - represented by the most recent level they have unlocked
    public static string[] SelectedPowerupNames = new string[4]; // the names of the selected powerups
    // IMPORTANT MAKE SURE POWERUPS IS SET TO "FishingRod" when you are done testing
    //, "Torpedo", "WaterGun", "Beer", "SpeedBoost", "ForceField", "Whirlpool", "Lightning","Reflect","SideCannon"
    public static List<string> UnlockedPowerupNames = new List<string> {"FishingRod"}; // the names of the unlocked powerups always starts out with the fishing rod 

    //, "PurpleBoat"
    public static List<string> UnlockedBoatNames = new List<string> {"WoodenBoat"}; // the names of the unlocked powerups always starts out with the fishing rod 
    public static float speed = 2f; // the players current speed from the boat
    public static float defaultSpeed = 2f;
    public static float maxSpeed = 6f; // the player's max speed from the boat
    public static float defaultMaxSpeed = 6f;
    public static float minSpeed = 2f; // the player's max speed from the boat
    public static float boostAmount = 2f; // the amount the player boosts from hitting in the green
    public static float greenZonePercent = 0.2f; // the percentage of the meter that the green zone takes up
    public static float turnSpeed = 100f; // the speed at which the player turns
    public static string boatName = "WoodenBoat"; // the name of the boat
    public static string levelToLoad = "RowingTutorial"; // the level to load when ready is pressed
    public static Sprite[] selectedPowerupSprites = new Sprite[4];
    public static bool[] selectedVariablesCT = new bool[4];
    public static Dictionary<string, Sprite> powerupIconDictionary = new Dictionary<string, Sprite>{
        {"Torpedo", Resources.Load<Sprite>("TinsleyPieces/PowerUps/Torpedo Animation")},
        {"SpeedBoost", Resources.Load<Sprite>("Materials/PowerUpIcons/speedBoost")},
        {"FishingRod", Resources.Load<Sprite>("Materials/PowerUpIcons/fishingRod")},
        {"Beer", Resources.Load<Sprite>("Materials/PowerUpIcons/beerCan")},
        {"WaterGun", Resources.Load<Sprite>("Materials/PowerUpIcons/waterGun")},
        {"ForceField", Resources.Load<Sprite>("Materials/PowerUpIcons/Forcefieldicon")},
        {"SideCannon", Resources.Load<Sprite>("Materials/PowerUpIcons/SideCannonIcon")},
        {"Whirlpool", Resources.Load<Sprite>("Materials/PowerUpIcons/Whirlpool")},
        {"Lightning", Resources.Load<Sprite>("Materials/PowerUpIcons/Lightning")},
        {"Reflect", Resources.Load<Sprite>("Materials/PowerUpIcons/Reflect")},
        
    };
    public static string previousScene = "OverWorld Map";
    public static int gold = 0;
    public static bool gamePaused = false;
    public static int collectedCoins;
    public static int lapscompleted = 0;
    public static bool halfwaycheckpointcrossed = false;
    public static bool OverWorldTutorialFinished = false;
    public static bool forcefieldActive = false;

    public static void SaveData()
    {
        SavedPlayerData data = new SavedPlayerData
        {
            playerLevel = playerLevel,
            UnlockedPowerupNames = UnlockedPowerupNames,
            UnlockedBoatNames = UnlockedBoatNames,
            boatName = boatName,
            levelToLoad = levelToLoad,
            gold = gold, 
            coinsAlreadyCollected = JsonConvert.SerializeObject(LevelData.coinsAlreadyCollected),
            OverWorldTutorialFinished = OverWorldTutorialFinished
        };

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
        Debug.Log("Player Data Saved.");
    }

    public static void LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string json = PlayerPrefs.GetString("PlayerData");
            SavedPlayerData data = JsonUtility.FromJson<SavedPlayerData>(json);

            playerLevel = data.playerLevel;
            UnlockedPowerupNames = data.UnlockedPowerupNames;
            UnlockedBoatNames = data.UnlockedBoatNames;
            boatName = data.boatName;
            levelToLoad = data.levelToLoad;
            gold = data.gold;
            OverWorldTutorialFinished = data.OverWorldTutorialFinished;
            LevelData.coinsAlreadyCollected = JsonConvert.DeserializeObject<Dictionary<string, bool[]>>(data.coinsAlreadyCollected);
        }
    }

}
