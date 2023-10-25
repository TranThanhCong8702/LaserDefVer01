using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfigSO> list;
    WaveConfigSO WaveConfigSO;
    [SerializeField] float timebtwwaves = 2f;
    [SerializeField] bool isLooping;
    int HigherDiffCount = 0;
    BackgroundScroll back;
    private void Awake()
    {
        back = FindObjectOfType<BackgroundScroll>();
    }
    void Start()
    {
        StartCoroutine(TheEnemySpawner());
    }

     public WaveConfigSO getCurrWave()
    {
        return WaveConfigSO;
    }
    IEnumerator TheEnemySpawner()
    {
        do
        {
            foreach (WaveConfigSO item in list)
            {
                WaveConfigSO = item;
                for (int i = 0; i < WaveConfigSO.GetenemyCount(); i++)
                {
                    Instantiate(WaveConfigSO.GetEnemyPrefabs(i), WaveConfigSO.GetStartWayPoints().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(WaveConfigSO.GetTimeVariance());
                }
                yield return new WaitForSeconds(timebtwwaves);
            }
            back.FasterBackground();
            timebtwwaves = timebtwwaves / 1.2f;
        }
        while (isLooping);
        
    }
    void Update()
    {
        
    }
}
