using System.Linq;
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
    public int playerplace;
    public static int[] boatcheckpointscrossed;
    void Start()
    {
      distances = new float[3];   // | PLAYER | ENEMY 1 | ENEMY 2 |
      boatcheckpointscrossed = new int[3];   // | PLAYER | ENEMY 1 | ENEMY 2 |
      checkpoint = GameObject.Find("Checkpoint");
      finishline = GameObject.Find("FinishLine");
      enemy1 = GameObject.Find("EnemyBoat1");
      enemy2 = GameObject.Find("EnemyBoat2");
    }

    // part of printing out boat name and progress
    void Update()
    {
      if(boatcheckpointscrossed[0]>boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]>boatcheckpointscrossed[2]){ // if the player has crossed more checkpoints than the enemies
        playerplace = 1;
      } else if (boatcheckpointscrossed[0]==boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]==boatcheckpointscrossed[2]) { // if they have the same number of checkpoints crossed
        getAllPlacingBetweenCheckpoints();
      } else if (boatcheckpointscrossed[0]<boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]<boatcheckpointscrossed[2]) { // if the player is behind on checkpoints
        playerplace = 3;
      } 
      else if (boatcheckpointscrossed[0]==boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]<boatcheckpointscrossed[2]) { // on the same one as 1 behind 2
        playerplace = getTwoPlacingBetweenCheckpoints(enemy1)+1;
      } else if (boatcheckpointscrossed[0]==boatcheckpointscrossed[2]
              && boatcheckpointscrossed[0]<boatcheckpointscrossed[1]) { // on the same one as 2 behind 1
        playerplace = getTwoPlacingBetweenCheckpoints(enemy2)+1;
      } else if (boatcheckpointscrossed[0]==boatcheckpointscrossed[2]
              && boatcheckpointscrossed[0]>boatcheckpointscrossed[1]) { // on the same one as 2 ahead of 1
        playerplace = getTwoPlacingBetweenCheckpoints(enemy2);
      } else if (boatcheckpointscrossed[0]==boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]>boatcheckpointscrossed[2]) { // on the same one as 1 ahead of 2
        playerplace = getTwoPlacingBetweenCheckpoints(enemy1);
      }
      else if((boatcheckpointscrossed[0]>boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]<boatcheckpointscrossed[2])
              || (boatcheckpointscrossed[0]<boatcheckpointscrossed[1]
              && boatcheckpointscrossed[0]>boatcheckpointscrossed[2])) { // inbetween the number of checkpoints passed as 1 and 2
        playerplace = 2;
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

    public int getPos(float[] distances) {
      float firstValue = distances[0];
        int rank = distances.OrderBy(x => x).ToList().IndexOf(firstValue) + 1;
        return rank;
    }

    public void getAllPlacingBetweenCheckpoints() {
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
      playerplace = getPos(distances);
    }
    public int getTwoPlacingBetweenCheckpoints(GameObject competitor) {
      float competitordistancetonextcheckpoint;
      float playerdistancetonextcheckpoint;
      if (PlayerData.halfwaycheckpointcrossed) {
        playerdistancetonextcheckpoint = distanceToFinish(gameObject.transform.position);
      } else {
        playerdistancetonextcheckpoint = distanceToCheckpoint(gameObject.transform.position);
      }  
      if (competitor.GetComponent<EnemyData>().halfwaycheckpointcrossed) {
        competitordistancetonextcheckpoint = distanceToFinish(competitor.transform.position);
      } else {
        competitordistancetonextcheckpoint = distanceToCheckpoint(competitor.transform.position);
      }
      if(playerdistancetonextcheckpoint>competitordistancetonextcheckpoint) {
        return 2;
      } else {
        return 1;
      }
    }

    public void incrementBoatCheckpointsCrossed() {
      if(gameObject.name=="Boat") {
        boatcheckpointscrossed[0]++;
      } else if(gameObject.name == "EnemyBoat1") {
        boatcheckpointscrossed[1]++;
      } else if(name == "EnemyBoat2") {
        boatcheckpointscrossed[2]++;
      }
    }
}
