using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform Target, Player;
    float mouseX, mouseY;

    private float zoom;
    private float zoomSpeed = 2.50f;
    private float zoomMin = -2f;
    private float zoomMax = -6f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        zoom = -3;
    }


    void Update()
    {
        CameraControl();
        ZoomCamera();
    }

    void CameraControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -50, 70);


        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.Tilde))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }


    }

    void OldZoom()
    {


        //if (Input.GetAxis("Mouse ScrollWheel") < 0) // Scroll wheel down
        //{
        //    if (maxZoom  > -6f) // Limits zoom distance
        //    {
        //        GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .50f); // Zoom out
        //    }
        //}

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    if (maxZoom < -2f)
        //    {
        //        GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z + .50f); // Zoom in
        //    }
        //}
    } // Old zoom method - Position of zoom was always the same, did not take player position into account.

    public void ZoomCamera() // Zooms camera in and out
    {
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
            zoom = zoomMin;

        if (zoom < zoomMax)
            zoom = zoomMax;

        transform.localPosition = new Vector3(0, 0, zoom);
    }
}
