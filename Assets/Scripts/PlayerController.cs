using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject self;
    private GameObject Body;
    public float speed = 0.5f;
    public fload maximumSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        Body = self.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /**/
        Rigidbody rigidBody = Body.GetComponent<Rigidbody>();
        
        float xMagnitude = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zMagnitude = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        rigidBody.AddRelativeForce(xMagnitude, 0.0f, zMagnitude, ForceMode.Impulse);
        
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

    }
}
