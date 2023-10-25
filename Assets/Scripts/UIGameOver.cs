using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        score.text ="Your score:" + scoreKeeper.GetScore().ToString();
    }


    void Update()
    {
        
    }
}
