using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// holds all UI event methods
public class UIController : MonoBehaviour {

	public GameController gameControl;
	public Stats stats;

	public Transform hypercubeTransform;

	public Animator scoreAnim;
	public Animator timePenaltyAnim;
	public Animator plusScoreAnim;
	public Animator comboAnim;
	public Animator hypercubeAnim;

	public Text scoreText;
	public Text timeText;
	public Text timePenaltyText;
	public Text plusScore;
	public Text comboText;
	public Text endGameScoreText;
	public Text highScoreText;
	public Text titleHighScoreText;

	public Image lastSphereImage;

	public Material lastSphereColorMat;
	public Material timePenaltyMat;

	public Color timePenaltyColor;
	public Color timeBonusColor;

	void Start () {
		lastSphereImage.enabled = false;
		titleHighScoreText.text = "high score  " + stats.HighScore.ToString();
	}
	
	void Update () {
		if (gameControl.TimeRemaining >= 0) {
			timeText.text = gameControl.TimeRemaining.ToString("F0");
		} else {
			timeText.text = "0";
		}
	}

	public void IncreaseCombo (int combo) {
		comboText.text = "COMBO X" + combo.ToString();
		comboAnim.SetTrigger("pop");
	}

	public void ResetCombo () {
		comboText.text = "COMBO RESET";
		comboAnim.SetTrigger("reset");
	}

	public void UpdateLastSphereColor (Color c) {
		if (!lastSphereImage.enabled) lastSphereImage.enabled = true;
		lastSphereColorMat.SetColor("_Color", c);
	}

	public void PostFinalScore (int score) {
		endGameScoreText.text = "your score  " + score.ToString();
		highScoreText.text = "high score  " + stats.HighScore.ToString();
		titleHighScoreText.text = "high score  " + stats.HighScore.ToString();
	}

	public void PostScore (int score) {
		scoreText.text = score.ToString();
		scoreAnim.SetTrigger("pop");
	}

	public void DisplayTimePenalty (int penalty) {
		timePenaltyMat.SetColor("_Color", timePenaltyColor);
		timePenaltyText.text = "-" + penalty.ToString();
		timePenaltyAnim.SetTrigger("pop");
	}

	public void DisplayTimeBonus (int bonus) {
		timePenaltyMat.SetColor("_Color", timeBonusColor);
		timePenaltyText.text = "+" + bonus.ToString();
		timePenaltyAnim.SetTrigger("pop");
	}

	public void DisplayPlusScore (int scoreIncrement) {
		plusScore.text = "+" + scoreIncrement.ToString();
		plusScoreAnim.SetTrigger("pop");
	}

	public void ToGameOver () {
		StartCoroutine(SlideZPos(hypercubeTransform, 20, -10, 1.5f, 2.0f));
	}

	public void ToGame () {
		StartCoroutine(SlideZPos(hypercubeTransform, 50, 20, 1.5f, 0.1f));
	}

	// coroutine to lerp hypercube position between the title, game, and end game screens.
	IEnumerator SlideZPos (Transform t, float startZ, float endZ, float duration, float delay) {
		yield return new WaitForSeconds(delay);
		float startTime = Time.time;
		float ease = 0;
		Vector3 v;
		while (ease < 0.99) {
			ease = Easing.EaseInOutCubic(Time.time - startTime, 0, 1f, duration);
			float z = ((endZ - startZ) * ease) + startZ;
			v = t.localPosition;
			v.z = z;
			t.localPosition = v;

			yield return null;
		}

		v = t.localPosition;
		v.z = endZ;
		t.localPosition = v;
	}
}
