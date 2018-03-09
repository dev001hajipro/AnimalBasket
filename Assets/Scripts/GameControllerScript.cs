using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

	void Start ()
	{
		Time.timeScale = 1;
		TimeLeftScript.timeLeft = 10f;
	}

	void Update ()
	{
		if (TimeLeftScript.timeLeft <= 0) {
			Time.timeScale = 0; // 時間停止
			this.gameObject.GetComponent<Utility> ().LoadScene (Utility.SCENE_RESULT);
		}
	}
}
