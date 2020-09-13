using System;
using Spawning;
using UnityEngine;

namespace Stats
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField]
        private Spawner _spawner;

        [SerializeField]
        private DeadBodyManager _deadBodyManager;

        public int KillCount;
        public float ElapsedTime;
        public int WaveCount;
        
        private void Start()
        {
            ElapsedTime = 0;
        }
        
        private void Update()
        {
            ElapsedTime += Time.deltaTime;
            KillCount = _deadBodyManager.TotalDeadBodyRetrieved;
            WaveCount = _spawner.CurrentWave;
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt("last_kill_count", KillCount);
            PlayerPrefs.SetFloat("last_time_survived", ElapsedTime);
            PlayerPrefs.SetInt("last_wave_count", WaveCount);

            int lastBestKillCount = PlayerPrefs.GetInt("best_kill_count", 0);

            if (KillCount > lastBestKillCount)
            {
                PlayerPrefs.SetInt("best_kill_count", KillCount);
            }
            
            int lastBestTime = PlayerPrefs.GetInt("best_time_survived", 0);

            if (ElapsedTime > lastBestTime)
            {
                PlayerPrefs.SetFloat("best_time_survived", ElapsedTime);
            }
            
            int lastBestWave = PlayerPrefs.GetInt("best_wave_count", 0);

            if (WaveCount > lastBestWave)
            {
                PlayerPrefs.SetInt("best_wave_count", WaveCount);
            }
        }
    }
}