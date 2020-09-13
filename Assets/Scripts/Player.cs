using Spawning;
using Stats;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player Current;

    public bool IsAlive = true;
    private Health _health;

    [SerializeField] private UnityEvent _onGameEnd;

    private void Start()
    {
        Current = GetComponent<Player>();
        _health = GetComponent<Health>();
    }

    public void SetAsDead()
    {
        IsAlive = false;

        if (!DeadBodyManager.Instance.isBodyAvailable)
        {
            _onGameEnd.Invoke();
        }
    }

    public void SetAsAlive()
    {
        IsAlive = true;
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
            SetAsAlive();
        }
    }
}