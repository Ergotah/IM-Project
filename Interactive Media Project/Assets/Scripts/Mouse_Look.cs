using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This code was written following a youtube tutorial by channel Brackeys
  The video is called FIRST PERSON MOVEMENT in unity -FPS Controller, posted on Oct 27, 2019
 link: https://www.youtube.com/watch?v=_QajrabyTJc */

public class Mouse_Look : MonoBehaviour
{
    public float mouseSensitivity = 100f;   //pick a sensitivity for the mouse location

    public Transform playerBody;

    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        //hide and lock cursor to center of screen to view around
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate independent of current frame rate by multiplying with deltatime
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //vertical rotation is done by getting the mouseY values and rotating the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //limit the rotation to 90 degrees up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       
        //Horizontal rotation is done using mouse X movement through playerbody
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
