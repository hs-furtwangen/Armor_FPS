using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody playerRigidbody;
    public float speed;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public ArmorBow bow;

    private float nextFire;
    private static int life = 3;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

	void FixedUpdate () {
        playerRigidbody.velocity = moveVelocity;
    }   

    private void Update(){
        //Horizontal and Vertical Input, if the player is trying to move
        //Input.GetAxis() has some slope
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(horizontalInput, verticalInput, 0f);
        moveVelocity = moveInput * speed;

        //creates a line from the camera to the current mouse position
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); //has to intersect with something for the player to look at
        Plane goundPlane = new Plane(Vector3.forward, new Vector3(0,0,2));
        float rayLength;

        //Raycast returns true if ray intersects with something
        if (goundPlane.Raycast(cameraRay, out rayLength)){//out rayLenght returns the Length of the hitting ray
            Vector3 pointToLookAt = Input.mousePosition;//cameraRay.GetPoint(rayLength);
            Debug.Log("ray: " + cameraRay.origin);
            Debug.DrawLine(cameraRay.origin, pointToLookAt, Color.cyan);

            //transform.LookAt(pointToLookAt);
        }

        if (Input.GetMouseButton(0))
            bow.isFireing = true;

        if (Input.GetMouseButtonUp(0))
            bow.isFireing = false;

        if (life == 0){
            GameOver.isPlayerDead = true;
        }
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
