using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System.Globalization;
using DG.Tweening;

[RequireComponent (typeof(Text))]
public class Score : MonoBehaviour
{
	public int addValue = 10;
	// TODO private.
	public Text scoreText;

	void Start ()
	{
		scoreText = GetComponent<Text> ();
	}

	public Tweener UpWithAnime ()
	{
		int endValue = Value + addValue;
		Store.Score = endValue;
		// ハイスコア更新
		if (Store.HiScore < Store.Score) {
			Store.HiScore = Store.Score;
		}
		return DOTween.To (() => Value, (n) => Value = n, endValue, 0.5f);
	}

	public int Value {
		get {
			// 00001のスタイルを1に変換
			return int.Parse (scoreText.text, NumberStyles.Any);
		}
		set {
			scoreText.text = value.ToString ("00000");
		}
	}
}
