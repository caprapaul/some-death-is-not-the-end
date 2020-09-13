using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int _sceneIndex;

    public void Load()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
