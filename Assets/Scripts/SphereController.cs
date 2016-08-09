using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour {

	public bool isBad;
	bool firstTouch = true; 

	public int typeNumber;

	public ParticleSystem particles;
	Screenshake screenshake;
	AudioController audioControl;

	void Start () {
		screenshake = GameObject.FindGameObjectWithTag("hypercube").GetComponent<Screenshake>();
		audioControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioController>();
	}

	// detect first collision with disk
	void OnCollisionEnter (Collision collider) {
		if (collider.gameObject.tag == "disk" && firstTouch) {
			StartCoroutine(screenshake.Shake(0.05f, 0.15f));
			particles.Emit(4);
			audioControl.Hit(Random.Range(0.7f, 1f));
			firstTouch = false;
		} else {
			audioControl.Hit(Random.Range(0.3f, 0.5f));
		}
	}
}
