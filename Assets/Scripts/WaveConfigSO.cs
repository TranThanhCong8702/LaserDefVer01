using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig", fileName = "new WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float movespeed = 5f;
    [SerializeField] float TimebtwSpawn = 1f;
    [SerializeField] float TimeVariance = 0f;
    [SerializeField] float MinspawnTime = 0.2f;
    public int GetenemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartWayPoints()
    {
        return pathPrefabs.GetChild(0);
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> list = new List<Transform>();
        foreach (Transform t in pathPrefabs)
        {
            list.Add(t);
        }
        return list;
    }
    public float GetMoveSpeed()
    {
        return movespeed;
    }
    public float GetTimeVariance()
    {
        float spawntime = Random.Range(TimebtwSpawn - TimeVariance, TimebtwSpawn + TimeVariance);
        return Mathf.Clamp(spawntime, MinspawnTime, float.MaxValue);
    }
}
