using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {
    public GameObject player;
    public float rotationSpeed = 5.0f;
    public float positionSmoothness = 0.125f;
    public float rotationSmoothness = 0.1f;
    public Vector3 offset;

    private Quaternion targetRotation;

    void Start() {
        offset = transform.position - player.transform.position;
        targetRotation = transform.rotation;
    }

    void LateUpdate() {
        // Calculate the desired rotation based on the player's forward direction on the XZ plane
        Vector3 forwardXZ = new Vector3(player.transform.forward.x, 0f, player.transform.forward.z);
        targetRotation = Quaternion.LookRotation(forwardXZ);
        float moveHorizontal = Input.GetAxis("Horizontal");
     
        // Smoothly rotate the camera towards the target rotation
        //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness);

        // Calculate the desired position of the camera
        Vector3 desiredPosition = player.transform.position + offset;

        // Smoothly update the camera's position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionSmoothness);

        // Removed the line that rotates the offset
    }
}
