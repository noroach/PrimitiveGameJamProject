using UnityEngine;
using System.Collections;

public class FlameParticle : MonoBehaviour {

	// if we rotate for effect at all, we do it to the particle, not this game object
	public GameObject FireCube;
	public float speed;
	public float rotationRate;
	public float decayTime;
	public float startSize;
	public float endSize;
	public float rotCountDown;

	public Material StartMat;
	public Material EndMat;

	public MeshRenderer FireRenderer;

	// Use this for initialization
	void Start () {
		rotCountDown = rotationRate;
		FireCube.transform.localScale = new Vector3 (startSize, startSize, startSize);
		//FireRenderer = FireCube.GetComponent<Renderer>();
		FireRenderer.material = StartMat;
	}
	
	// Update is called once per frame
	void Update () {
		Decay ();
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		Rotate ();
		InterpolateSize ();
		InterpolateMaterial ();
	}

	// checks if it should kill itself
	void Decay(){
		decayTime -= Time.deltaTime;
		if (decayTime < 0f) {
			Destroy (FireCube); // the cube is dependent on the gameObject and must be destroyed first
			Destroy (gameObject);
		}
	}

	// checks if the time is at a rotation interval
	void Rotate(){
		if (rotCountDown < 0) {
			FireCube.transform.rotation = Quaternion.Euler (Random.Range (0, 180), Random.Range (0, 180), Random.Range (0, 180));
			rotCountDown = rotationRate;
		} else {
			rotCountDown -= Time.deltaTime;
		}
	}

	// moves from the start size to the end size at the rate of decay time
	void InterpolateSize(){
		Vector3 endScale = new Vector3 (endSize, endSize, endSize);
		FireCube.transform.localScale = Vector3.Lerp (FireCube.transform.localScale, endScale, (1f / decayTime) * Time.deltaTime);
	}

	void InterpolateMaterial(){
		float lerptime = (1f / decayTime * Time.deltaTime) * 2;
		Material currentMat = FireRenderer.material;
		// basically what we did ininterpolate size but for the material colors
		FireRenderer.material.Lerp(currentMat, EndMat, lerptime);
	}
}
