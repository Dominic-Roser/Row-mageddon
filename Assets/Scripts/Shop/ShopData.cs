using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static List<string> availableItems = new List<string>{"Beer", "Torpedo", "SpeedBoost", "WaterGun"};
    public static List<string> allItems = new List<string>{"FishingRod", "Beer", "Torpedo", "SpeedBoost", "WaterGun"};

    public static List<string> availableBoats = new List<string>{"PurpleBoat", "Dragon boat"};
    public static List<string> allBoats = new List<string>{"WoodenBoat", "PurpleBoat", "Dragon boat"};

    public static Dictionary<string, int> itemPrices = new Dictionary<string, int>{
        {"Torpedo", 20},
        {"SpeedBoost", 8},
        {"FishingRod", 0},
        {"Beer", 12},
        {"WaterGun", 15},
        {"Dragon boat", 50},
        {"PurpleBoat", 20},
        {"WoodenBoat", 0},
    };
    public static string displayBoatName = "WoodenBoat"; 
}
