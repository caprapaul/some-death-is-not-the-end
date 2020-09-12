using Cinemachine;
using UnityEngine;
using UnityEngine.U2D;
using System.Reflection;

/// <summary>
/// Add this component to a camera that has PixelPerfectCamera and CinemachineBrain
/// components to prevent the active CinemachineVirtualCamera from overwriting the
/// correct orthographic size as calculated by the PixelPerfectCamera.
/// </summary>
[RequireComponent(typeof(PixelPerfectCamera), typeof(CinemachineBrain))]
class OrthographicOverride : MonoBehaviour
{
    private CinemachineBrain _cinemachineBrain;
    private object _internal; // PixelPerfectCameraInternal
    private FieldInfo _orthoInfo;

    void Start()
    {
        _cinemachineBrain = GetComponent<CinemachineBrain>();
        _internal = typeof(PixelPerfectCamera).GetField("m_Internal", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GetComponent<PixelPerfectCamera>());
        _orthoInfo = _internal.GetType().GetField("orthoSize", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    void LateUpdate()
    {
        CinemachineVirtualCamera cam = _cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
        
        if (cam)
        {
            cam.m_Lens.OrthographicSize = (float) _orthoInfo.GetValue(_internal);
        }
    }
}