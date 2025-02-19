using NUnit.Framework;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyItem);

        // if the player has already unlocked the powerup fade it an disable button functionality
        if(PlayerData.UnlockedPowerupNames.Contains(name)){
            purchaseItemVisuals();
        } else {

        }

    }
    // Update is called once per frame
    void BuyItem()
    {
        // if the player can afford it
        if(PlayerData.gold>=ShopData.powerupPrices[name]){
            // if the player hasn't unlocked the powerup yet and it's a buyable powerup add it to their powerups
            if (!PlayerData.UnlockedPowerupNames.Contains(name) && ShopData.allItems.Contains(name)) {
                PlayerData.UnlockedPowerupNames.Add(name);
                ShopData.availableItems.Remove(name);

                purchaseItemVisuals();
                // TODO change the new srting to the array of boats in shop data
                recordShopPurchaseEvent(PlayerData.playerLevel, PlayerData.gold, ShopData.availableItems.ToArray(), new string[0], name); 
                
                PlayerData.gold -= ShopData.powerupPrices[name]; // deduct price from player gold
                Debug.Log("Item: " + name + " purchased.");
            }
        }
    }

    void purchaseItemVisuals()
    {
        Color tempcolor = GetComponent<Image>().color;
        tempcolor.a = 0.3f;
        GetComponent<Image>().color = tempcolor;
        GetComponent<Button>().enabled = false;
    }
    public static void recordShopPurchaseEvent(int playerLevel, int gold, string[] availablePowerups, string[] availableBoats, string purchasedItem) {
        if (AnalyticsData.analyticsActive) { 
            ShopPurchaseEvent shopPurchaseEvent = new ShopPurchaseEvent
            {
                playerLevel = playerLevel,
                gold = gold,
                availablePowerups = availablePowerups,
                availableBoats = availableBoats,
                purchasedItem = purchasedItem,

            };

            AnalyticsService.Instance.RecordEvent(shopPurchaseEvent);
            Debug.Log("Shop purchase event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
