using UnityEngine;
using System.Collections;

// notifies game controller script when a sphere falls off the edge of the disk
public class Bottom : MonoBehaviour {

	public GameController gameControl;

	void OnTriggerEnter (Collider collider) {
		gameControl.SphereDeath(collider.gameObject);
	}
}
