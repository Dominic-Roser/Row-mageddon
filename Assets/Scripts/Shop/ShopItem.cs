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
        if(name!="Boat" && PlayerData.gold >= ShopData.itemPrices[name]){
            // if the player hasn't unlocked the powerup yet and it's a buyable powerup add it to their powerups
            if (!PlayerData.UnlockedPowerupNames.Contains(name) && ShopData.allItems.Contains(name)) {
                PlayerData.UnlockedPowerupNames.Add(name);
                ShopData.availableItems.Remove(name);

                purchaseItemVisuals();
                // TODO change the new srting to the array of boats in shop data
                recordShopPurchaseEvent(PlayerData.playerLevel, PlayerData.gold, ShopData.availableItems.ToArray(), ShopData.availableBoats.ToArray(), name);
                
                PlayerData.gold -= ShopData.itemPrices[name]; // deduct price from player gold
                Debug.Log("Item: " + name + " purchased.");
                PlayerData.SaveData();
            } 
        } else if (name == "Boat" && PlayerData.gold >= ShopData.itemPrices[ShopData.displayBoatName]) {
            if (!PlayerData.UnlockedBoatNames.Contains(ShopData.displayBoatName) && ShopData.allBoats.Contains(ShopData.displayBoatName)) {
                PlayerData.UnlockedBoatNames.Add(ShopData.displayBoatName);
                ShopData.availableBoats.Remove(ShopData.displayBoatName);

                purchaseBoatVisuals();
                recordShopPurchaseEvent(PlayerData.playerLevel, PlayerData.gold, ShopData.availableItems.ToArray(), ShopData.availableBoats.ToArray(), ShopData.displayBoatName); 


                PlayerData.gold -= ShopData.itemPrices[ShopData.displayBoatName]; // deduct price from player gold
                Debug.Log("Item: " + ShopData.displayBoatName + " purchased.");
                PlayerData.SaveData();
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
    void purchaseBoatVisuals()
    {
        Color tempcolor = GetComponent<Image>().color;
        tempcolor.a = 0.3f;
        GetComponent<Image>().color = tempcolor;
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
