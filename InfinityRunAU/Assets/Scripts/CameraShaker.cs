using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [Header("Camera Shaker Config")]
    private Vector3 CameraInitialPosition;
    [SerializeField] float shakeMagnitude = 0.05f;
    [SerializeField] float shakeTime = 0.5f;
    [SerializeField] Camera mainCamera;


    public void ShakeIt()
    {
        CameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;

        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = CameraInitialPosition;
    }













}
