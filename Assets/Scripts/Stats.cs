using UnityEngine;
using System.Collections;

// handles high score saving using PlayerPrefs
public class Stats : MonoBehaviour {

	private string highScoreKey = "highScore";

	public int HighScore {
		get { return PlayerPrefs.GetInt(highScoreKey); }
		set { PlayerPrefs.SetInt(highScoreKey, value); }
	}

	void Start () {
		if (!PlayerPrefs.HasKey(highScoreKey)) {
			HighScore = 0;
		}
	}
}
