using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered Trigger " + other.name);
    }
}
