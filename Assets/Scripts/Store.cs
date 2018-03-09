using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Store : MonoBehaviour
{
	public static int Score {
		set {
			PlayerPrefs.SetInt ("Score", value);
			PlayerPrefs.Save ();
		}
		get {
			if (!PlayerPrefs.HasKey ("Score"))
				Score = 0;
			return PlayerPrefs.GetInt ("Score");
		}
	}

	public static int HiScore {
		set {
			PlayerPrefs.SetInt ("HiScore", value);
			PlayerPrefs.Save ();
		}
		get {
			if (!PlayerPrefs.HasKey ("HiScore"))
				HiScore = 0;
			return PlayerPrefs.GetInt ("HiScore");
		}
	}

	public static int Music {
		set {
			PlayerPrefs.SetInt ("Music", value);
			PlayerPrefs.Save ();
		}
		get {
			if (!PlayerPrefs.HasKey ("Music"))
				Music = 1;
			return PlayerPrefs.GetInt ("Music");
		}
	}
}
