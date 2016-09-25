using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	//gun stats, will take these from the global player settings
	public float MainGunDamage;
	public float MainGunRateOfFire;
	public GameObject MainBulletPrefab;

	// we also need all the gun positions
	public GameObject MainGunLeft;
	public GameObject MainGunRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")){
			MainFire ();
		}
	}

	void MainFire(){
		// when we instantiate we also need to set which layer the bullet is on
		// because by default - they are enemy bullets
		Vector3 LeftPos = new Vector3(transform.position.x,  transform.position.y, transform.position.z);
		Quaternion bulletRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
		Instantiate(MainBulletPrefab, MainGunLeft.transform.position, bulletRot);  //left bullet
		Instantiate(MainBulletPrefab, MainGunRight.transform.position, bulletRot); //right bullet
	}



}
