using Unity.Mathematics;
using UnityEngine;

public class RaceProgressTracker5678 : MonoBehaviour
{
    private float raceProgress = 0f; // 0-100% 
    public float RaceProgress => raceProgress;
    private GameObject checkpoint;
    private GameObject finishline;
    private float[] distances;
    private GameObject enemy1;
    private GameObject enemy2;
    void Start()
    {
      distances = new float[3];   // | PLAYER | ENEMY 1 | ENEMY 2 |
      checkpoint = GameObject.Find("Checkpoint");
      enemy1 = GameObject.Find("EnemyBoat1");
      enemy2 = GameObject.Find("EnemyBoat2");
    }

    // part of printing out boat name and progress
    void Update()
    {
      if (PlayerData.halfwaycheckpointcrossed) {
        distances[0] = distanceToFinish(gameObject.transform.position);
      } else {
        distances[0] = distanceToCheckpoint(gameObject.transform.position);
      }  
      if (enemy1.GetComponent<EnemyData>().halfwaycheckpointcrossed) {
        distances[1] = distanceToFinish(enemy1.transform.position);
      } else {
        distances[1] = distanceToCheckpoint(enemy1.transform.position);

      }
      if (enemy2.GetComponent<EnemyData>().halfwaycheckpointcrossed) {
        distances[2] = distanceToFinish(enemy2.transform.position);
      } else {
        distances[2] = distanceToCheckpoint(enemy2.transform.position);
      }
    }

    public float distanceToFinish(Vector3 pos){ 
      Vector3 finishlinepos = finishline.transform.position;
      return Vector3.Distance(finishlinepos, pos);
    }
    public float distanceToCheckpoint(Vector3 pos){ 
      Vector3 checkpointpos = checkpoint.transform.position;
      return Vector3.Distance(checkpointpos, pos);
    }
}
