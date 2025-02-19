using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static List<string> availableItems = new List<string>{"Beer", "Torpedo", "SpeedBoost", "WaterGun"};
    public static List<string> allItems = new List<string>{"FishingRod", "Beer", "Torpedo", "SpeedBoost", "WaterGun"};

    public static Dictionary<string, int> powerupPrices = new Dictionary<string, int>{
        {"Torpedo", 25},
        {"SpeedBoost", 10},
        {"FishingRod", 0},
        {"Beer", 15},
        {"WaterGun", 20},
    };
}
