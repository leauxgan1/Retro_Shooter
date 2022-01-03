using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform body;
    public float lookSpeed = 1.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Start() {
        body = player.transform.GetChild(0).gameObject.transform;
    }

    void Update()
    {
        updateRotation();
        setRotation();
        setPlayerRotation();
    }

    void updateRotation() {
        yaw += lookSpeed * Input.GetAxis("Mouse X");            
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
    }

    void setRotation() {
        //UnityEngine.Debug.Log("Pitch: " + pitch + ", Yaw: " + yaw);
        if (pitch < -90) 
        {
            pitch = -90.0f;
        }
        else if(pitch > 90) 
        {
            pitch = 90.0f;
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void setPlayerRotation() {
        body.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}