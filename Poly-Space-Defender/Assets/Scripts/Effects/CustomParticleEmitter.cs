﻿using UnityEngine;
using System.Collections;

public class CustomParticleEmitter : MonoBehaviour {

	// rate is not even fucking implemented
	public float EmissionRate;
	public float Spread;
	public GameObject CustomParticle; // as to not confuse with Unitys built in particle system

	float emCountDown;

	// Use this for initialization
	void Start () {
		emCountDown = EmissionRate;
	}
	
	// Update is called once per frame
	void Update () {
		//CheckRate ();
		SpawnParitcle();
	}

	void CheckRate(){
		if(emCountDown < 0f){
			SpawnParitcle ();
			emCountDown = EmissionRate;
		} else{
			emCountDown -= Time.deltaTime;
		}
	}
	void SpawnParitcle(){
		Vector3 p = transform.position; // its shorthand and looks better?
		Vector3 randPos = new Vector3((Random.Range(p.x - Spread, p.x + Spread)) , (Random.Range(p.y - Spread, p.y + Spread)) , (Random.Range(p.z - Spread, p.z + Spread)));
		GameObject newParticle = Instantiate (CustomParticle, randPos, transform.rotation) as GameObject;
		//newParticle.transform.SetParent (transform);
	}
}