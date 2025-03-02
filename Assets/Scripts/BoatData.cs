using System.Collections.Generic;
using UnityEngine;

public class BoatData : MonoBehaviour {
  public static Dictionary<string, float> boatMaxSpeed = new Dictionary<string, float>{
      {"Dragon boat", 7.0f},
      {"PurpleBoat", 6.5f},
      {"WoodenBoat", 6.0f},
  };
  public static Dictionary<string, float> boatDefaultMaxSpeed = new Dictionary<string, float>{
      {"Dragon boat", 7.0f},
      {"PurpleBoat", 6.5f},
      {"WoodenBoat", 6.0f},
  };
  public static Dictionary<string, float> boatBoostAmount = new Dictionary<string, float>{
      {"Dragon boat", 2.33f},
      {"PurpleBoat", 2.15f},
      {"WoodenBoat", 2.0f},
  };
}