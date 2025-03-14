using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static List<string> availableItems = new List<string>{"Beer", "Torpedo", "SpeedBoost", "WaterGun", "SideCannon", "Whirlpool", "Lightning", "Reflect", "ForceField"};
    public static List<string> allItems = new List<string>{"FishingRod", "Beer", "Torpedo", "SpeedBoost", "WaterGun", "SideCannon", "Whirlpool", "Lightning", "Reflect", "ForceField"};

    public static List<string> availableBoats = new List<string>{"PurpleBoat", "Dragon boat"};
    public static List<string> allBoats = new List<string>{"WoodenBoat", "PurpleBoat", "Dragon boat"};

    //
    public static Dictionary<string, int> itemPrices = new Dictionary<string, int>{
        {"Torpedo", 25},
        {"SpeedBoost", 10},
        {"FishingRod", 0},
        {"Beer", 18},
        {"WaterGun", 10},
        {"Whirlpool", 18},
        {"SideCannon", 28},
        {"Lightning", 30},
        {"Reflect", 30},
        {"ForceField", 30},
        {"Dragon boat", 50},
        {"PurpleBoat", 28},
        {"WoodenBoat", 0}
    };
    public static string displayBoatName = "WoodenBoat"; 
}
