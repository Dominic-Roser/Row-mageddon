using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {
  public static Dictionary<string, bool[]> coinsAlreadyCollected = new Dictionary<string, bool[]>{
      {"Level5", new bool[11]}
    };
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
    public static Dictionary<string, int> TotalLaps = new Dictionary<string, int>{
      {"newRacing", 1},
      {"Level1", 1},
      {"Level2", 1},
      {"Level3", 1},
      {"Level4", 1},
      {"Level5", 3},
      {"Level6", 2},
      {"Level7", 2},
      {"Level8", 3},
      {"Level9", 3},
      {"Level10", 3},
    };
}