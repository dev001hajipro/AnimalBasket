using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class TimeLeftScript : MonoBehaviour
{

	private Text text;

	public static float timeLeft = 10f;

	void Start ()
	{
		text = GetComponent<Text> ();

	}

	void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 0;
		
		text.text = "のこり " + Mathf.Round (timeLeft) + " 秒";

	}
}
