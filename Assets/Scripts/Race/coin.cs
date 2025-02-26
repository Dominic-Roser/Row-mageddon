using Unity.VisualScripting;
using UnityEngine;

public class coin : MonoBehaviour {
  public int index;
  public static bool[] currCollected;
  void Start()
  {
    currCollected = (bool[]) PlayerData.coinsAlreadyCollected[PlayerData.levelToLoad].Clone();
    index = getIndex();
    // if the coin is already collected make it disappear
    if(currCollected[index]){
      gameObject.SetActive(false);
    }
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.name == "Boat") {
      PlayerData.collectedCoins++;
      Debug.Log("coin number "+ index + " collected collected coins is now: " + PlayerData.collectedCoins);
      gameObject.SetActive(false);
      currCollected[index] = true;
    }
  }

  int getIndex(){
    if(gameObject.name.Length<=4){
      return 0;
    } else {
      string name = gameObject.name;
      int start = name.IndexOf("(") + 1;  // Position after '('
      int length = name.IndexOf(")") - start;  // Length of the number
      int coinNum = int.Parse(name.Substring(start, length));
      return coinNum;
    }
  }
}