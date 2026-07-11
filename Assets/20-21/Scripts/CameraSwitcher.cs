using System;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;
    
    private Queue<CinemachineVirtualCamera> _cameraQueue = new Queue<CinemachineVirtualCamera>();

    private void Start()
    {
        foreach (CinemachineVirtualCamera camera in _cameras)
        {
            _cameraQueue.Enqueue(camera);
        }
        
        SwitchCamera();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        foreach (var camera in _cameraQueue)
        {
            camera.enabled = false;
        }
        
        CinemachineVirtualCamera nextCamera = _cameraQueue.Dequeue();
        nextCamera.enabled = true;
        _cameraQueue.Enqueue(nextCamera);
    }
}
