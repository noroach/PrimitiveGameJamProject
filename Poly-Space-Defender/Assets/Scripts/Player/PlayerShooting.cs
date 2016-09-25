using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	//gun stats, will take these from the global player settings
	public float BulletSpeed;
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
		if (Input.GetButton ("Fire1")){
			MainFire ();
		}
	}

	void MainFire(){
		GameObject TempBulletLeft;
		GameObject TempBulletRight;
		TempBulletLeft = Instantiate (MainBulletPrefab, MainGunLeft.transform.position, transform.rotation) as GameObject;
		TempBulletRight = Instantiate (MainBulletPrefab, MainGunRight.transform.position, transform.rotation) as GameObject;

		Rigidbody LeftBody;
		Rigidbody RightBody;
		LeftBody = TempBulletLeft.GetComponent<Rigidbody> ();
		RightBody = TempBulletRight.GetComponent<Rigidbody> ();

		LeftBody.AddForce (-transform.forward * BulletSpeed);
		RightBody.AddForce (-transform.forward * BulletSpeed);

		Destroy (TempBulletLeft, 5f);
		Destroy (TempBulletRight, 5f);
	}



}
