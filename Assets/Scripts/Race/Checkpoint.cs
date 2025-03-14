using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D other) {
      if(!PlayerData.halfwaycheckpointcrossed && other.gameObject.name == "Boat") {
        PlayerData.halfwaycheckpointcrossed = true;
        if(isLapLevel()){
          other.gameObject.GetComponent<RaceProgressTracker5678>().incrementBoatCheckpointsCrossed();
        }
      }
      else if(other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyData>().halfwaycheckpointcrossed) {
        other.gameObject.GetComponent<EnemyData>().halfwaycheckpointcrossed = true;
        if(isLapLevel()){
          other.gameObject.GetComponent<RaceProgressTracker5678>().incrementBoatCheckpointsCrossed();
        }
      }
    }

    private bool isLapLevel(){
      return PlayerData.levelToLoad == "Level6" || PlayerData.levelToLoad == "Level8";
    }
}
