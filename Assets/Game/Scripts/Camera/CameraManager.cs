using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Cinemachine;
using System;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    public CameraState CameraState;

    [SerializeField]
    private CinemachineCamera _tpsCamera;

    [SerializeField]
    private CinemachineCamera _fpsCamera;

    [SerializeField]
    private InputManager _inputManager;

    public Action OnChangePerspective;

    private void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }
    private void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }

    private void SwitchCamera()
    {
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tpsCamera.gameObject.SetActive(false);
            _fpsCamera.gameObject.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tpsCamera.gameObject.SetActive(true);
            _fpsCamera.gameObject.SetActive(false);
        }
        OnChangePerspective();
    }


}