using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnWave()
    {
        foreach (WaveConfig wave in waveConfigs)
        {
            Instantiate(wave);
        }
        yield return new WaitForSeconds(2.0f);
    }
}
