using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private GameObject self;
    private GameObject Body;
    private Rigidbody BodyPhysics;
    public float speed = 0.5f;
    public float jumpForce = 1.0f;
    public float maximumSpeed = 10.0f;
    public float groundDistance = 0.1f;
    public enum State {
        Grounded,
        Jumping
    }
    private State state;

    void Start()
    {
        self = gameObject;
        Body = self.transform.GetChild(0).gameObject;
        BodyPhysics = Body.GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveHorizontal();
        
    }

    void FixedUpdate()  {
        moveVertical(); 
    }

    void moveHorizontal() {
        float xMagnitude = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zMagnitude = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if(state == State.Grounded) {
            BodyPhysics.AddRelativeForce(xMagnitude, 0.0f, zMagnitude, ForceMode.Impulse);
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
        else if(state == State.Jumping) {
            //Set the acceleration in the player's movement direction
            resetState();
        }
        constrainHorizontalSpeed();
    }

    void constrainHorizontalSpeed() {
        if(state == State.Grounded) {
            if(BodyPhysics.velocity.magnitude > maximumSpeed) {
                Vector3 newVel = Vector3.ClampMagnitude(BodyPhysics.velocity, maximumSpeed);
                BodyPhysics.velocity = newVel;
            }
        }
        else if(state == State.Jumping) {

        }
        
    }

    void moveVertical() {
        if(Input.GetKey(KeyCode.Space) && state != State.Jumping) {
            state = State.Jumping;
            Debug.Log("Jumping");
            BodyPhysics.AddRelativeForce(0.0f, jumpForce, 0.0f, ForceMode.Impulse);
        }
    }

    void resetState() {
        float distToGround = Body.GetComponent<Collider>().bounds.extents.y;
        if(Physics.Raycast(Body.transform.position, -Vector3.up,distToGround + groundDistance)) {
            Debug.Log("Grounded");
            state = State.Grounded; 
        }
    }
}
