using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Spawning;
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
    private Spawner _spawner;

    [SerializeField]
    private DeadBodyManager _deadBodyManager;

    void Update()
    {
        _timeText.text = Time.time.ToString("0.0") + "s";
        _killsText.text = _deadBodyManager.TotalDeadBodyRetrieved.ToString();
        _waveText.text = _spawner.CurrentWave.ToString();
    }
}
