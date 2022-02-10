using UnityEngine;
using System.Collections;

// AimBehaviour inherits from GenericBehaviour. This class corresponds to aim and strafe behaviour.
public class Aim : MonoBehaviour
{
	//public float aimTurnSmoothing = 0.15f;                                // Speed of turn response when aiming to match camera facing.

	private int aimBool;                                                  // Animator variable related to aiming.
	private bool aim;

	public Transform target;
	public Camera cam;
	public Vector3 targetLocation;
	//public Transform crosshairPos;

	public GameObject enemy;
	// Boolean to determine whether or not the player is aiming.

	// Start is always called after any Awake functions.
	void Start ()
	{
		// Set up the references.
		//aimBool = Animator.StringToHash("Aim");
		//GetComponent<Animator>().applyRootMotion = false;
	}

	// Update is used to set features regardless the active behaviour.
	void Update()
	{
		if (aim)
        {
			targetLocation = cam.WorldToScreenPoint(target.position);
			//crosshairPos.position = targetLocation;
			Rotating();
		}

		// Activate/deactivate aim by input.
		if (Input.GetMouseButtonDown(1)  && !aim)
		{

			targetLocation = cam.WorldToScreenPoint(target.position);
			aim = true;
			GetComponent<Animator>().SetBool(aimBool, aim);

			//crosshairPos.gameObject.SetActive(true);
		}
		else if (aim && Input.GetMouseButtonDown(1))
		{

			aim = false;
			GetComponent<Animator>().SetBool(aimBool, aim);

			//crosshairPos.gameObject.SetActive(false);
		}

	}

	// Rotate the player to match correct orientation, according to camera.
	void Rotating()
	{
		
		Vector3 forward = cam.transform.TransformDirection(target.position - transform.position);
		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		Quaternion targetRotation = Quaternion.LookRotation(forward);

		// Always rotates the player according to the camera horizontal rotation in aim mode.
		//Quaternion targetRotation =  Quaternion.Euler(0, 1, 0);

		float minSpeed = Quaternion.Angle(transform.rotation, targetRotation); //* aimTurnSmoothing;

		// Rotate entire player to face camera.
		//behaviourManager.SetLastDirection(forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, minSpeed * Time.deltaTime);
	}

}
