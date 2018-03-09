using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	private TimeLeftScript script;

	void Start ()
	{
		script = GameObject.Find ("TimeLeftText").GetComponent<TimeLeftScript> ();
	}

	void Update ()
	{
		if (script.timeLeft <= 0) {
			this.gameObject.GetComponent<Utility> ().GoToResultWithoutAnime ();
		}
	}
}
