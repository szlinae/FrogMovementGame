using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;
    public float jumpForce = 100.0f;
    public float jumpVal = 10.0f;
    public float chargingP = 0.0f;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    //private bool Jump = false;
    private Rigidbody rBody;
    private Vector3 startingPosition;
    private Vector3 someVec;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //player.transform.position += Movement * speed * Time.deltaTime;
        someVec = rBody.transform.up + rBody.transform.forward;
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;  

        //Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0 );
        //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

        if (Input.GetKeyDown(KeyCode.W))
        {
            //if (grounded) {
            rBody.AddForce(someVec.normalized * jumpVal,  ForceMode.Impulse);
            //}
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            Quaternion target = Quaternion.Euler(0, tiltAngle, 0 );
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        }
        
        //charge jump
        if (Input.GetKeyDown(KeyCode.Space)){
            chargingP += .1f;
            Debug.Log("SDf");
        }
        //jump on release
        if (Input.GetKeyUp(KeyCode.Space)){
            //Jump = true;
            rBody.AddForce(someVec.normalized * chargingP * jumpForce,  ForceMode.Impulse);
            Debug.Log("sdf");
                
        }
        
    }
   /* void FixedUpdate()
    {
        if (Jump)
        {
            rBody.AddForce(someVec * chargingP * jumpForce,  ForceMode.Impulse);
            Jump = false;
            chargingP = 0;
        }
    }*/
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "platform")
        {
            rBody.constraints = RigidbodyConstraints.FreezePosition;
            //rBody.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log("yas");
        }
    }
}
