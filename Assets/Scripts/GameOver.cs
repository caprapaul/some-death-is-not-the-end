using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;

    [SerializeField]
    private TextMeshProUGUI _killsText;

    [SerializeField]
    private TextMeshProUGUI _waveText;

    void Update()
    {
        _timeText.text = PlayerPrefs.GetInt("last_time_survived", 0).ToString("0.0");
        _killsText.text = PlayerPrefs.GetFloat("last_kill_count", 0).ToString();
        _waveText.text = PlayerPrefs.GetInt("last_wave_count", 0).ToString();
    }
}
