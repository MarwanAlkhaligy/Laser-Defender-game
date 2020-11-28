using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "waveconfig")]
public class Wave : ScriptableObject {
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] GameObject pathPrefabs;
    [SerializeField] float timeBetweenWaves = 0.5f;
    [SerializeField] float randomFactor = 0.1f;
    [SerializeField] int numOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    public GameObject GetEnemyPrefabs() { return EnemyPrefabs;}
  
    public List <Transform> GetWavewaypoints()  { 
        
        var wavewaypoint = new List<Transform>();
        foreach (Transform child in pathPrefabs.transform) 
        {
            wavewaypoint.Add(child);
        }
    
        return wavewaypoint;
     }

    public float GetTimeBetweenWaves() {  return timeBetweenWaves;}

    public float GetNumOfEnemies () {  return numOfEnemies ;}

    public float GetMoveSpeed () {     return moveSpeed ;}

    public float GetRandomFactor () {     return randomFactor ;}
}

