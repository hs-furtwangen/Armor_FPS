using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBow : MonoBehaviour {

    public bool isFireing;
    public ArrowController arrow;
    public float arrowSpeed;
    public float timeBetweenShot;
    public Transform arrowRest;
    private float shotCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFireing){
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0){
                shotCounter = timeBetweenShot;
                ArrowController newArrow = Instantiate(arrow, arrowRest.position, arrowRest.rotation) as ArrowController;
                newArrow.speed = arrowSpeed;
            }
        }
	}
}
