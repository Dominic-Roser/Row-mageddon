using System;
using Unity.Services.Analytics;
public class ShopPurchaseEvent : Event
    {
        public ShopPurchaseEvent() : base("ShopPurchaseEvent")
        {
        }
        public int playerLevel { set { SetParameter("playerLevel", value); } }
        public int gold { set { SetParameter("gold", value); } }
        public string[] availablePowerups { set { SetParameter("availablePowerups", string.Join(",", value)); } }
        public string[] availableBoats { set { SetParameter("availableBoats", string.Join(",", value)); } }
        public string purchasedItem { set { SetParameter("purchasedItem", value); } }
    }