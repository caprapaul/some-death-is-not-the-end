using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;

    public bool isAlive = true;
    
    private void Start()
    {
        Current = GetComponent<Player>();
    }

    public void SetAsDead()
    {
        isAlive = false;
    }

    public void SetAsAlive()
    {
        isAlive = true;
    }
}