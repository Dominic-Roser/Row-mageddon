using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private bool boatinside;
    private void OnTriggerExit2D(Collider2D other) {
      if(boatinside && other.gameObject.name == "Boat") {
        PlayerData.halfwaycheckpointcrossed = true;
        Debug.Log("checkpoint crossed");
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.name == "Boat") {
        boatinside = true;
      }
    }
}