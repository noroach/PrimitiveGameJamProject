﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
    public Transform ShipTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        LockCamera();
    }

    void LockCamera(){
        // get closer to the ships location, then set the distance from the ship
        Vector3 IdealCameraTransform = new Vector3(ShipTransform.position.x, ShipTransform.position.y + 2f, ShipTransform.position.z + 8f);
        transform.position = Vector3.Lerp(transform.position, IdealCameraTransform, 0.02f);
        //transform.position = new Vector3(transform.position.x, transform.position.y  + 2f, transform.position.z + 8f);
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}