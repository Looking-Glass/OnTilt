using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour {

	private float screenShakeTime;
	public float ScreenShakeTime {
		get { return screenShakeTime; }
		set { screenShakeTime = value; }
	}

	private float screenshakeMagnitude;
	public float ScreenshakeMagnitude {
		get { return screenshakeMagnitude; }
		set { screenshakeMagnitude = value; }
	}

	public Vector3 defaultCubePos;
	float magnitude;

	// stops screen shake coroutines.
	public void StopShake () {
		StopAllCoroutines();
	}

	// screen shake coroutine
	public IEnumerator Shake (float magnitude, float duration) {
		float startTime = Time.time;
		float ease = 1;
		while (ease > 0.01f) {
			ease = 1 - Easing.EaseInOutSine(Time.time - startTime, 0, 1f, duration);
			Vector3 v = Random.insideUnitSphere * ease * magnitude;
			transform.localPosition = defaultCubePos + v;

			yield return null;
		}
		transform.localPosition = defaultCubePos;
	}

	// screen shake coroutine with weighted direction vector
	public IEnumerator Shake (float magnitude, float duration, Vector3 direction) {
		float startTime = Time.time;
		float ease = 1;
		while (ease > 0.01f) {
			ease = 1 - Easing.EaseInOutSine(Time.time - startTime, 0, 1f, duration);
			Vector3 v = ((Random.insideUnitSphere * 0.5f) + direction) * ease * magnitude;
			transform.localPosition = defaultCubePos + v;

			yield return null;
		}
		transform.localPosition = defaultCubePos;
	}
}
