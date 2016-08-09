using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	public GameController gameControl;
	public ParticleSystem particles;
	public Material particleMat;

	// detect a ball going through a hole
	void OnTriggerEnter (Collider collider) {
		Color ballColor = collider.gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
		particleMat.SetColor("_Color", ballColor);
		particles.Emit(150);
		gameControl.SetScore(collider.gameObject);
	}
}
