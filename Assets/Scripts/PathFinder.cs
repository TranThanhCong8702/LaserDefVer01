using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WaveConfigSO waveConfigSO;
    List<Transform> listWaypoints;
    int waypointsIndex;
    EnemySpawner enemySpawner;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void Start()
    {
        waveConfigSO = enemySpawner.getCurrWave();   
        listWaypoints = waveConfigSO.GetWayPoints();
        transform.position = listWaypoints[waypointsIndex].position;
    }
    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if(listWaypoints.Count > waypointsIndex)
        {
            Vector3 targetPos = listWaypoints[waypointsIndex].position;
            float delta = waveConfigSO.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);
            if(transform.position == targetPos) {
                waypointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
