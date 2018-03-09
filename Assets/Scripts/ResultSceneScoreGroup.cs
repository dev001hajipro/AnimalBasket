using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneScoreGroup : MonoBehaviour
{

	void Start ()
	{
		Debug.Log (transform.Find ("HiScoreText"));
		transform.Find ("HiScoreText").GetComponent<Text> ().text = "HISCORE " + Store.HiScore.ToString ("00000");
		transform.Find ("ScoreText").GetComponent<Text> ().text = "SCORE " + Store.Score.ToString ("00000");
	}
}
