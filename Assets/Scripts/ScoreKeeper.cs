using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float Score = 0f;
    static ScoreKeeper scoreKeeper;

    private void Awake()
    {
        SingleScKeeper();
    }

    private void SingleScKeeper()
    {
        if(scoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void AddScore(float points)
    {
        Score += points;

    }
    public float GetScore()
    {
        return Score;
    }

    public void Reser()
    {
        Score = 0f;
    }
}
