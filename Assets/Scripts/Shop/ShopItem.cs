using NUnit.Framework;
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
                PlayerData.gold-=ShopData.powerupPrices[name]; // deduct price from player gold
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
}
