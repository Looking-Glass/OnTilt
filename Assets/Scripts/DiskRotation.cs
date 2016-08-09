using UnityEngine;
using System.Collections;

public class DiskRotation : MonoBehaviour {

	public Rigidbody rb;

	public float maxRotateAngle;
	public float rotateSpeed;
	float xSpeed;
	float zSpeed;
	float easeAmount = 0.15f;
	float startYRot;

	public KeyCode xUp;
	public KeyCode xDown;
	public KeyCode zUp;
	public KeyCode zDown;

	public GameController gameControl;

	void Start () {
		startYRot = transform.rotation.eulerAngles.y;	
	}
	
	void Update () {
		if (gameControl.Begin) {
			Control();	
		}
	}

	void FixedUpdate () {
		RotateRigidbody();
	}

	void Control () {
		// detect if a joystick is active. use joystick if one is, otherwise use the keyboard. 
		// note: if a joystick was attached and gets disconnected, unity doesn't seem to remove it from the Input.GetJoystickNames() array
		if (Input.GetJoystickNames().Length > 0) {
			// use joystick
			float x = Input.GetAxis("RightHorizontal");
			float y = Input.GetAxis("RightVertical");

			// x axis and z axis angle movement easing functions
			xSpeed += ((rotateSpeed * x) - xSpeed) * easeAmount;
			zSpeed += ((rotateSpeed * y) - zSpeed) * easeAmount;
		} else {
			// use arrow keys
			if (Input.GetKey(xUp)) {
				xSpeed += (rotateSpeed - xSpeed) * easeAmount;
			} else if (Input.GetKey(xDown)) {
				xSpeed += (-rotateSpeed - xSpeed) * easeAmount;
			} else {
				xSpeed += (0 - xSpeed) * easeAmount;
			}

			if (Input.GetKey(zUp)) {
				zSpeed += (-rotateSpeed - zSpeed) * easeAmount;
			} else if (Input.GetKey(zDown)) {
				zSpeed += (rotateSpeed - zSpeed) * easeAmount;
			} else {
				zSpeed += (0 - zSpeed) * easeAmount;
			}	
		}
	}

	// apply euler rotation values to transform using rigidbody physics.
	void RotateRigidbody () {
		float x = rb.rotation.eulerAngles.x + (xSpeed * Time.deltaTime);
		float z = rb.rotation.eulerAngles.z + (zSpeed * Time.deltaTime);
		if (x > maxRotateAngle && x < (360 - maxRotateAngle)) {
			x = rb.rotation.eulerAngles.x;
		}
		if (z > maxRotateAngle && z < (360 - maxRotateAngle)) {
			z = rb.rotation.eulerAngles.z;
		}
			
		rb.MoveRotation(Quaternion.Euler(new Vector3(x, startYRot, z)));
	}
}
