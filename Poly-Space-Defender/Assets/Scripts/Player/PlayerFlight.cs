using UnityEngine;
using System.Collections;

public class PlayerFlight : MonoBehaviour {

    public float MovementSpeed = 1f;

    public float InputDampeningHorizontal = 0f; // these 2 varibles are for interpolating between rotation angles in HandleRoatation()
    public float InputDampeningVertical = 0f;
	public float InputSmothingFactor = 0.2f;

    // -1 for star fox inverted, 1 for not -- will give players the option to change
    public int Inverted;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (new Vector3(-Input.GetAxis("Horizontal"), Inverted * Input.GetAxis("Vertical"))) * MovementSpeed * Time.deltaTime;
        HandleRotation();
	}

    //z rot from -45 to 45 when turning left or right
    // 15 to -15 in x for tilt up and down
    void HandleRotation() {
		//these first varible are for the max rotation that the ship can lean given an input
		float maxXrot = 20f;
		float maxYrot = 10f;
		float maxZrot = 45f;

        // esentially, the input moves closer to the new input intead of snapping to it
		InputDampeningHorizontal = InputDampeningHorizontal + (InputSmothingFactor * (Input.GetAxis("Horizontal") - InputDampeningHorizontal));
		InputDampeningVertical = InputDampeningVertical + (InputSmothingFactor * (Input.GetAxis("Vertical") - InputDampeningVertical));

		//old - save for fall back
		//transform.rotation = Quaternion.Euler(InputDampeningVertical * maxXrot, transform.rotation.y, InputDampeningHorizontal * maxZrot);

		transform.rotation = Quaternion.Euler(InputDampeningVertical * maxXrot, InputDampeningHorizontal * maxYrot, InputDampeningHorizontal * maxZrot);
    }
}
