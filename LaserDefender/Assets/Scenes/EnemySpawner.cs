using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        WaveConfig currentwave = waveConfigs[startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentwave));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {

            GameObject newEnemyClone = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].position, Quaternion.identity);

            newEnemyClone.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBeetweenSpawns());

        }
    }
}
