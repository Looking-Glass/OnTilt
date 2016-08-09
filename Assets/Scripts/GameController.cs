using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public float dropZoneMaxRadius;
	public float dropZoneMinRadius;
	public float numberToBeginWith;
	public int timePenalty;

	[SerializeField]
	private float timeRemaining;
	public float TimeRemaining {
		get { return timeRemaining; }
		set { 
			timeRemaining = value;
		}
	}

	private int score;
	public int Score {
		get { return score; }
		set { score = value; }
	}
	int pointsPerScore = 10;
	int consecutiveSpheresToGainExtraTime = 3;
	int lastSphereTypeScored;
	int consecutiveSpheresOfSameTypeScored = 1;

	private bool gameOver;
	public bool GameOver {
		get { return gameOver; }
		set { gameOver = value; }
	}
	private bool begin;
	public bool Begin {
		get { return begin; }
		set { 
			begin = value;
			FirstDrop();
		}
	}
	bool moveToBegin = true;

	bool allowReload = false;

	public GameObject[] dropPrefabs;

	public UIController uiControl;
	public DiskPulse diskPulse;
	public Screenshake screenshake;
	public Stats stats;
	public AudioController audioControl;

	void Start () {

	}
	
	void Update () {
		if (Begin) {
			// check for time remaining in round and trigger game over when time has run out.
			TimeRemaining -= Time.deltaTime;
			if (TimeRemaining <= 0 && !GameOver) {
				GameOver = true;
				screenshake.StopShake();
				uiControl.ToGameOver();
				uiControl.PostFinalScore(Score);
				Invoke("AllowReload", 4);
				if (score > stats.HighScore) {
					stats.HighScore = score;
				}
			}	
		} else {
			if (Input.anyKeyDown && moveToBegin) {
				moveToBegin = false;
				audioControl.OnButtonPress();
				StartCoroutine(BeginGame());
			}
		}

		if (GameOver) {
			if (Input.anyKeyDown && allowReload) {
				audioControl.OnButtonPress();
				Reload();
			}
		}
	}

	IEnumerator BeginGame () {
		uiControl.ToGame();
		yield return new WaitForSeconds(1.0f);
		Begin = true;
	}

	void AllowReload () {
		allowReload = true;
	}

	public void SetScore (GameObject sphere) {
		// handle score event
		if (!GameOver) {
			SphereController sphereControl = sphere.GetComponent<SphereController>();
			if (sphereControl.isBad) {
				TimeRemaining -= timePenalty;
				uiControl.DisplayTimePenalty(timePenalty);
				audioControl.OnPenalty();
				if (consecutiveSpheresOfSameTypeScored > 1) {
					uiControl.ResetCombo();
				}
				consecutiveSpheresOfSameTypeScored = 1;
			} else {
				if (sphereControl.typeNumber == lastSphereTypeScored) {
					consecutiveSpheresOfSameTypeScored++;
					uiControl.IncreaseCombo(consecutiveSpheresOfSameTypeScored);
					if (consecutiveSpheresOfSameTypeScored == consecutiveSpheresToGainExtraTime) {
						TimeRemaining += timePenalty;
						uiControl.DisplayTimeBonus(timePenalty);
					}
				} else {
					if (consecutiveSpheresOfSameTypeScored > 1) {
						uiControl.ResetCombo();
					}
					consecutiveSpheresOfSameTypeScored = 1;
				}
				Score += pointsPerScore * consecutiveSpheresOfSameTypeScored;
				lastSphereTypeScored = sphereControl.typeNumber;
				uiControl.PostScore(score);
				uiControl.DisplayPlusScore(Mathf.RoundToInt(pointsPerScore * consecutiveSpheresOfSameTypeScored));
				audioControl.OnScore();
			}
				
			StartCoroutine(screenshake.Shake(0.15f, 0.1f, Vector3.down));
			Color pulseColor = sphere.GetComponent<MeshRenderer>().material.GetColor("_Color");
			StartCoroutine(diskPulse.PulseEmission(0.5f, 0.3f, pulseColor));
			uiControl.UpdateLastSphereColor(pulseColor);
			SphereDeath(sphere);	
		}
	}

	// replace a sphere with a new one
	public void SphereDeath (GameObject obj) {
		Destroy(obj);
		Drop();
	}

	// set up first sphere drops
	void FirstDrop () {
		for (int i = 0; i < numberToBeginWith; i++) {
			GameObject drop = Instantiate(dropPrefabs[i % dropPrefabs.Length]) as GameObject;
			drop.transform.position = DropPosition();
		}
	}

	// drop a new sphere on the disk
	void Drop () {
		if (!GameOver) {
			GameObject[] spheres = GameObject.FindGameObjectsWithTag("spheres");
			bool badSphereIsActive = false;
			foreach (GameObject sphere in spheres) {
				if (sphere.GetComponent<SphereController>().isBad) {
					badSphereIsActive = true;
				}
			}
			int dropIndex;
			if (!badSphereIsActive) {
				dropIndex = 0;
			} else {
				dropIndex = Random.Range(0, dropPrefabs.Length);
			}
			GameObject drop = Instantiate(dropPrefabs[dropIndex]) as GameObject;
			drop.transform.position = DropPosition();	
		}
	}

	// get a valid sphere drop postion
	Vector3 DropPosition () {
		//returns a suitable position to drop a new ball from in an orthographic circular band
		//doesn't currently raycast to check if disk is below 
		Vector2 circlePos = Random.insideUnitCircle;
		circlePos = (circlePos.normalized * dropZoneMinRadius) + (circlePos * (dropZoneMaxRadius - dropZoneMinRadius));
		Vector3 result = new Vector3(circlePos.x, 8, circlePos.y);
		return result;
	}

	// reload scene
	void Reload () {
		diskPulse.ResetColor();
		SceneManager.LoadScene(0);
	}

	// reset disk color on application quit
	void OnApplicationQuit () {
		diskPulse.ResetColor();
	}
}
