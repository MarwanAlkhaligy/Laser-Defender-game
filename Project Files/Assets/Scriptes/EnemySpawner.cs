using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Wave> waveconfig;
    [SerializeField]int startingwave = 0;
    private IEnumerator Start()
    {
       while(true)
       {
           yield return StartCoroutine(SpawnAllWaves());
       }
        
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingwave; waveIndex < waveconfig.Count ; waveIndex++) 
        {
           var currentwave = waveconfig[waveIndex];
           yield return   StartCoroutine(SpawnAllEnemiesInWave(currentwave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(Wave waveconfig)
    {
        
       for(int index = 0; index < waveconfig.GetNumOfEnemies() ; index++)
       {
            var newEnemy  = Instantiate(
            waveconfig.GetEnemyPrefabs(),
            waveconfig.GetWavewaypoints()[0].transform.position,
            Quaternion.identity );
            newEnemy.GetComponent<EnemyPathing>().SetWave(waveconfig);
            yield return new WaitForSeconds(waveconfig.GetTimeBetweenWaves());
            //index++;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
