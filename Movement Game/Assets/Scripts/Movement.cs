using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;
    public float jumpForce = 100.0f;
    public float chargingP = 0.0f;

    private bool Jump = false;
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
        Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.transform.position += Movement * speed * Time.deltaTime;

        //charge jump
        if (Input.GetMouseButton(0)){
            chargingP += 0.001f;
        }
        //jump on release
        if (Input.GetMouseButtonUp(0)){
                Jump = true;
                
        }
        someVec = rBody.transform.up + rBody.transform.forward;
    }
    void FixedUpdate()
    {
        if (Jump)
        {
            rBody.AddForce(someVec * chargingP * jumpForce,  ForceMode.Impulse);
            Jump = false;
            chargingP = 0;
        }
    }
}
