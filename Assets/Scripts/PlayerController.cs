using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject self;
    private GameObject Body;
    private Rigidbody BodyPhysics;
    public float speed = 0.5f;
    public float maximumSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        Body = self.transform.GetChild(0).gameObject;
        BodyPhysics = Body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /**/
        
        float xMagnitude = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zMagnitude = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        BodyPhysics.AddRelativeForce(xMagnitude, 0.0f, zMagnitude, ForceMode.Impulse);
        constrainSpeed();
        /*
        if(Input.GetKey(KeyCode.W)) {
             transform.position += Body.transform.forward * Time.deltaTime * speed;
         }
         else if(Input.GetKey(KeyCode.S)) {
             transform.position -= Body.transform.forward * Time.deltaTime * speed;
         }
         else if(Input.GetKey(KeyCode.A)) {
             transform.position -= Body.transform.right * Time.deltaTime * speed;
         }
         else if(Input.GetKey(KeyCode.D)) {
             transform.position += Body.transform.right * Time.deltaTime * speed;
         }
         //*/
    }

    void constrainSpeed() {
        if(BodyPhysics.velocity.magnitude > maximumSpeed) {
            Vector3 newVel = Vector3.ClampMagnitude(BodyPhysics.velocity, maximumSpeed);
            BodyPhysics.velocity = newVel;
        }
    }
}
