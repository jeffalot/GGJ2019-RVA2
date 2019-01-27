using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HumanController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f; //Change in inspector to adjust move speedVector3 forward, right; // Keeps track of our relative forward and right vectorsvoid Start()

    Vector3 forward, right;
    bool inVehicle = false;
    public GameObject activeVehicle;
    public Rigidbody rb;
    bool scooterMode = false;
    float lastScootTime;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0; // make sure y is 0
        forward = Vector3.Normalize(forward); // make sure the length of vector is set to a max of 1.0
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; // set the right-facing vector to be facing right relative to the camera's forward vector

        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.anyKey && !scooterMode) // only execute if a key is being pressed
            Move();

        if (Input.anyKeyDown & scooterMode) // only execute if a key is being pressed
            MoveScooter();
    }
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); // Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"); // Up movement uses the forward vector, movement speed, and the vertical axis inputs.Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving in
        transform.position += rightMovement; // move our transform's position right/left
        transform.position += upMovement; // Move our transform's position up/down

        //rb.AddForce((rightMovement + upMovement));

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving intransform.position += rightMovement; // move our transform's position right/left     transform.position += upMovement; // Move our transform's position up/down

       


    }

    void MoveScooter()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); // Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"); // Up movement uses the forward vector, movement speed, and the vertical axis inputs.Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving in
        //transform.position += rightMovement; // move our transform's position right/left
        //transform.position += upMovement; // Move our transform's position up/down

        rb.AddForce((rightMovement + upMovement), ForceMode.Impulse);

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); // This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0transform.forward = heading; // Sets forward direction of our game object to whatever direction we're moving intransform.position += rightMovement; // move our transform's position right/left     transform.position += upMovement; // Move our transform's position up/down




    }

    void OnTriggerEnter(Collider collider)
    {
        print("Trigger occurred");
        if (collider.gameObject.tag.Equals("Vehicle"))
        {
            VehicleHandle(collider.gameObject, true);
        }

        if (collider.gameObject.tag.Equals("GameOver"))
        {
            GameObject.Find("Menu UI").GetComponent<GameOver>().isGameOver = true;
        }
    }


    //If entering vehicle, entrance is true
    void VehicleHandle(GameObject vehicle, bool entrance)
    {


        //Iterate through all vehicle types for now, figure out how to do this better later
        //TODO
        try
        {
            vehicle.GetComponent<SimpleCarController>().enabled = entrance;
            vehicle.GetComponent<SimpleCarController>().driver = this.gameObject;
            //activeVehicle = vehicle;
        }
        catch
        {

        }


        //If exiting, set new pos
        //Trying naive set transform
        this.gameObject.transform.position = new Vector3(vehicle.transform.position.x + 1f, vehicle.transform.position.y, vehicle.transform.position.z);



        //Turn off human for now
        this.gameObject.active = !entrance;
    }

}