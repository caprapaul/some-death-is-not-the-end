using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Current;

    private void Start()
    {
        Current = GetComponent<Player>();
    }
}