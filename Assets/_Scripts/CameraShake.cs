using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1f;
    public float ShakeTime = 1f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        // Find the CinemachineVirtualCamera component dynamically
        CinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (CinemachineVirtualCamera != null)
        {
            _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera not found in the scene.");
        }
    }

    public void ShakeCameraAndDisableVirtualCamera()
    {
        if (CinemachineVirtualCamera != null && _cbmcp != null)
        {
            // Enable the CinemachineVirtualCamera
            CinemachineVirtualCamera.enabled = true;

            // Start the camera shake
            _cbmcp.m_AmplitudeGain = ShakeIntensity;
            timer = ShakeTime;

            // Start coroutine to stop the shake and disable the CinemachineVirtualCamera
            StartCoroutine(StopShakeAndDisableVirtualCamera());
        }
    }

    public IEnumerator StopShakeAndDisableVirtualCamera()
    {
        yield return new WaitForSeconds(ShakeTime);

        // Stop the shake
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;

        // Disable the CinemachineVirtualCamera
        CinemachineVirtualCamera.enabled = false;
    }
}
