using System;
using System.Collections.Generic;

[Serializable]
public class SavedPlayerData
{
    public int playerLevel;
    public List<string> UnlockedPowerupNames;
    public List<string> UnlockedBoatNames;
    public string boatName;
    public string levelToLoad;
    public int gold;
    public Dictionary<string, bool[]> coinsAlreadyCollected;
}