using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform cameraPosition;
    // public float sx;
    //public float sy;
    //public float xAngle, yAngle;
    public float smoothspeed = 0.125f;
    public Vector3 offset;



    // Update is called once per frame
    void Start()
    {
        //  transform.Rotate(Vector3.down, 0, Space.World);
        // transform.Rotate(Vector3.right, 0, Space.World);
    }
    private void LateUpdate()
    {
        Vector3 dp = cameraPosition.TransformPoint(offset);
        Vector3 dps = Vector3.Lerp(cameraPosition.position, dp, smoothspeed);
        transform.position = dps;
        transform.LookAt(cameraPosition, Vector3.up);



        //freelook try scripts
        // xAngle=  Input.GetAxis("Mouse X") * Time.deltaTime;
        // yAngle=  Input.GetAxis("Horizontal") * Time.deltaTime;
        // float xPos = Mathf.Clamp(xAngle, -45f, 45f);
        // float yPos = Mathf.Clamp(yAngle, -35f, 35f);
        // transform.Rotate(Vector3.down, xPos*sx, Space.World);
        //transform.Rotate(Vector3.right, yAngle*sy, Space.Self);





    }
}