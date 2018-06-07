﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float UpDownSpeed = 50f;
    float LeftRightSpeed = 50f;

    float scrollSpeed = 0.7f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
        {
            float speedW;

            if (transform.position.x >= 3)
            {
                speedW = UpDownSpeed * Time.deltaTime;
            }
            else
            {
                speedW = 0;
            }

            transform.position = new Vector3(transform.position.x - speedW, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("s"))
        {
            float speedS;

            if (transform.position.x <= 77)
            {
                speedS = UpDownSpeed * Time.deltaTime;
            }
            else
            {
                speedS = 0;
            }

            transform.position = new Vector3(transform.position.x + speedS, transform.position.y, transform.position.z);

        }
        if (Input.GetKey("a"))
        {
            float speedA;

            if (transform.position.z >= -1)
            {
                speedA = LeftRightSpeed * Time.deltaTime;
            }
            else
            {
                speedA = 0;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedA);
        }
        if (Input.GetKey("d"))
        {
            float speedD;

            if (transform.position.z <= 73)
            {
                speedD = LeftRightSpeed * Time.deltaTime;
            }
            else
            {
                speedD = 0;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speedD);
        }




        if ((Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey("q")) && transform.position.y <= 60) // -0.1 w dół // oddalanie
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed, transform.position.z);
        }
        

        if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey("e")) && transform.position.y >= 10) // 0.1 w górę // przyblizanie
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - scrollSpeed, transform.position.z);
        }

    /*
        if (Input.GetMouseButton(1))
        {
            float xRot = -Input.GetAxis("Mouse Y");
            float yRot = Input.GetAxis("Mouse X");


            transform.eulerAngles += new Vector3(xRot, yRot, 0);
        }
*/

    }
}