using System;
using Spawning;
using Stats;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;

    public bool isAlive = true;
    private Health _health;

    private void Start()
    {
        Current = GetComponent<Player>();
        _health = GetComponent<Health>();
    }

    public void SetAsDead()
    {
        isAlive = false;
    }

    public void SetAsAlive()
    {
        isAlive = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        var deadBody = other.gameObject.GetComponent<DeadBody>();

        if (deadBody == null)
            return;
        
        if (!deadBody.IsAlive)
        {
            deadBody.RemoveItCompletely();
            _health.RestoreAll();
        }
    }
}