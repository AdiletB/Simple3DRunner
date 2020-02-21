using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed, sideForce, defaultSpeed;
    
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.AddForce(0, 0, speed * Time.deltaTime);

        if(Input.GetKey("d")){
            rigidBody.AddForce(sideForce * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("a")){
            rigidBody.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }
        
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetSpeed()
    {
        return this.speed;
    }
    public float GetDefaultSpeed()
    {
        return this.defaultSpeed;
    }
}
