using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

	void Update ()
	{
		if (TimeLeftScript.timeLeft <= 0) {
			Time.timeScale = 0; // 時間停止
		}
	}

	public void RestartScene ()
	{
	}

	public void ResetGame ()
	{
		Time.timeScale = 1;
		TimeLeftScript.timeLeft = 10f;
		//restartButton.gameObject.SetActive (false);
		//timeIsUpText.gameObject.SetActive (false);
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
