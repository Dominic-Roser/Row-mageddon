using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D other) {
      if(other.gameObject.name == "Boat") {
        PlayerData.halfwaycheckpointcrossed = true;
      }
      if(other.gameObject.tag == "Enemy") {
        other.gameObject.GetComponent<EnemyData>().halfwaycheckpointcrossed = true;
      }
    }
}