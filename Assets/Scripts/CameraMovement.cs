using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float upDownSpeed = 50f;
    float leftRightSpeed = 50f;

    float scrollSpeed = 0.7f;

	void Update () {
        if (Input.GetKey("w"))
        {
            float speedW;

            if (transform.position.x >= 3)
                speedW = upDownSpeed * Time.deltaTime;
            else
                speedW = 0;

            transform.position = new Vector3(transform.position.x - speedW, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("s"))
        {
            float speedS;

            if (transform.position.x <= 77)
                speedS = upDownSpeed * Time.deltaTime;
            else
                speedS = 0;

            transform.position = new Vector3(transform.position.x + speedS, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("a"))
        {
            float speedA;

            if (transform.position.z >= -1)
                speedA = leftRightSpeed * Time.deltaTime;
            else
                speedA = 0;

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedA);
        }
        if (Input.GetKey("d"))
        {
            float speedD;

            if (transform.position.z <= 73)
                speedD = leftRightSpeed * Time.deltaTime;
            else
                speedD = 0;

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedD);
        }

        if ((Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey("q")) && transform.position.y <= 60) // -0.1 w dół // oddalanie
            transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed, transform.position.z);
        
        if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey("e")) && transform.position.y >= 10) // 0.1 w górę // przyblizanie
            transform.position = new Vector3(transform.position.x, transform.position.y - scrollSpeed, transform.position.z);
    }
}
