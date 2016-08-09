using UnityEngine;
using System.Collections;

// makes object persist between scene changes.
public class Persist : MonoBehaviour {

	private static Persist persist = null;

	void Awake ()
	{
		if (persist == null)
		{
			DontDestroyOnLoad(this);
			persist = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
