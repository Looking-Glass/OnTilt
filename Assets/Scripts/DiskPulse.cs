using UnityEngine;
using System.Collections;

public class DiskPulse : MonoBehaviour {

	public Material diskMat;
	public Color startColor;

	void Start () {
		ResetColor();
	}
	
	void Update () {
	
	}

	// pusle the emission color of the disk material
	public IEnumerator PulseEmission (float duration, float pulseIntensity, Color pulseColor) {
		float startTime = Time.time;
		diskMat.SetColor("_EmissionColor", pulseColor);
		float ease = 0;
		while (ease < 0.99) {
			ease = Easing.EaseOutCubic(Time.time - startTime, 0, 1, duration);
			Color currentColor = Color.Lerp(pulseColor, startColor, ease);
			diskMat.SetColor("_EmissionColor", currentColor);
			yield return null;
		}
		ResetColor();
	}

	// reset emission color on disk. this turned out to be required because the emission color was automatically being set to black for some reason, which breaks the PulseEmission method
	public void ResetColor () {
		diskMat.SetColor("_EmissionColor", startColor);
	}
}
