using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Spawning;
using Stats;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;

    [SerializeField]
    private TextMeshProUGUI _killsText;

    [SerializeField]
    private TextMeshProUGUI _waveText;


    [SerializeField]
    private StatsManager _statsManager;
    void Update()
    {
        _timeText.text = _statsManager.ElapsedTime.ToString("0.0") + "s";
        _killsText.text = _statsManager.KillCount.ToString();
        _waveText.text = _statsManager.WaveCount.ToString();
    }
}
