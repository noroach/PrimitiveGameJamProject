using UnityEngine;
using System.Collections;

public class NoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, 180, 0);
	}
}
