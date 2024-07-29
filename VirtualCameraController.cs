using UnityEngine;
using Cinemachine;

public class VirtualCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float followDistance = 5f;
    public float followHeight = 2f;
    public float followSmoothTime = 0.2f;
<|im_start|> assistant
    private CinemachineVirtualCamera virtualCamera;
    private Vector3 smoothVelocity;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position - playerTransform.forward * followDistance;
            targetPosition.y += followHeight;

            Vector3 currentPosition = virtualCamera.transform.position;
            Vector3 targetVelocity = (targetPosition - currentPosition) / followSmoothTime;

            currentPosition = Vector3.SmoothDamp(currentPosition, targetPosition, ref smoothVelocity, followSmoothTime);

            virtualCamera.transform.position = currentPosition;
        }
    }
}
