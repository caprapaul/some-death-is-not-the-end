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
    
    [SerializeField]
    private TextMeshProUGUI _bestTimeText;

    [SerializeField]
    private TextMeshProUGUI _bestKillsText;

    [SerializeField]
    private TextMeshProUGUI _bestWaveText;

    void Start()
    {
        _timeText.text = PlayerPrefs.GetFloat("last_time_survived", 0).ToString("0.0");
        _killsText.text = PlayerPrefs.GetInt("last_kill_count", 0).ToString();
        _waveText.text = PlayerPrefs.GetInt("last_wave_count", 0).ToString();
        
        _bestTimeText.text = PlayerPrefs.GetFloat("best_time_survived").ToString("0.0");
        _bestKillsText.text = PlayerPrefs.GetInt("best_kill_count").ToString();
        _bestWaveText.text = PlayerPrefs.GetInt("best_wave_count").ToString();

    }
}
