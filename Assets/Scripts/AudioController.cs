using UnityEngine;
using System.Collections;

// holds all the audio event methods
public class AudioController : MonoBehaviour {

	public AudioSource audio1;
	public AudioSource audio2;

	public AudioClip scoreSFX;
	public AudioClip penaltySFX;
	public AudioClip hitSFX;
	public AudioClip buttonSFX;

	float defaultVolume = 1f;

	void Start () {
	
	}
	
	public void OnScore () {
		DefaultAudioValues();
		audio1.PlayOneShot(scoreSFX);
	}

	public void OnPenalty () {
		DefaultAudioValues();
		audio1.PlayOneShot(penaltySFX);
	}

	public void Hit (float volume) {
		audio2.pitch = Random.Range(0.8f, 1.2f);
		audio2.volume = volume;
		audio2.PlayOneShot(hitSFX);
	}

	public void OnButtonPress () {
		DefaultAudioValues();
		audio1.PlayOneShot(buttonSFX);
	}

	void DefaultAudioValues () {
		audio1.volume = defaultVolume;
		audio1.pitch = 1f;
		audio2.volume = defaultVolume;
		audio2.pitch = 1f;
	}
}
