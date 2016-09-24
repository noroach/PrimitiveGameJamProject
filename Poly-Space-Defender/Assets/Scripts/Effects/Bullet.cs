using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Rigidbody bullet;
	public float velocity;

	public Material PlayerBulletMat;
	public Material EnemyBulletMat;


	// Use this for initialization
	void Start () {
		bullet = gameObject.GetComponent<Rigidbody> ();
		Shoot ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Shoot () {
		bullet.AddForce (transform.up * velocity, ForceMode.VelocityChange);
	}
}
