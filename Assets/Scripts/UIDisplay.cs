using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Health PlayerHealth;
    [SerializeField] Slider slider;

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }
    void Start()
    {
        slider.maxValue = PlayerHealth.GetHP();
    }

    void Update()
    {
        slider.value = PlayerHealth.GetHP();
        textMeshProUGUI.text = scoreKeeper.GetScore().ToString("00000000");
    }
}
