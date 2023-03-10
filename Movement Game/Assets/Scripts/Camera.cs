using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Camera cam; 
    public float lookSpeed = 2.0f;
    float rotationX = 0;
    float rotationY = 0;
    //public float lookXLimit = 45.0f;
    //public GameObject player;
    //public float sensitivity;
 
/*     void FixedUpdate ()
     {  
         float rotateHorizontal = Input.GetAxis ("Mouse X");
         float rotateVertical = Input.GetAxis ("Mouse Y");
         transform.RotateAround (player.transform.position, -Vector3.up, rotateHorizontal * sensitivity); 
         //transform.Rotate(-transform.up * rotateHorizontal * sensitivity);
         transform.RotateAround (Vector3.zero, transform.right, rotateVertical * sensitivity); 
         //transform.Rotate(transform.right * rotateVertical * sensitivity);
     }
}*/

    void Update()        
    {       
            
            rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX -= Input.GetAxis("Mouse X") * lookSpeed;
            //rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            cam.transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
            transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed , 0);

           /*rotationY += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY = Mathf.Clamp(rotationY, -lookXLimit, lookXLimit);
            cam.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse Y") * lookSpeed, 0);*/
    }
}