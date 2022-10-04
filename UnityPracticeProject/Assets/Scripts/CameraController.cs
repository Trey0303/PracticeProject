using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float playerCameraDistance { get; set; }
    public Transform cameraTarget;

    Camera playerCamera;
    float zoomSpeed = 35;

    private void Start()
    {
        playerCameraDistance = 4;
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            playerCamera.fieldOfView -= scroll * zoomSpeed;
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 10, 80);
        }

        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + playerCameraDistance, cameraTarget.position.z - playerCameraDistance);
    }
}
