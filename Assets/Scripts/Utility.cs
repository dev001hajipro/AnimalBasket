using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Utility : MonoBehaviour
{
	public const int SCENE_TITLE = 0;
	public const int SCENE_MAIN = 1;
	public const int SCENE_RESULT = 2;

	void Start ()
	{
		Debug.Log ("start utility");
	}

	private void LoadScene (int sceneBuildIndex)
	{
		SceneManager.LoadScene (sceneBuildIndex);
	}

	public void GoToMain ()
	{
		LoadSceneWithAnime (() => SceneManager.LoadScene (SCENE_MAIN));
	}

	public void GoToTitle ()
	{
		LoadSceneWithAnime (() => SceneManager.LoadScene (SCENE_TITLE));
	}

	public void GoToResultWithoutAnime ()
	{
		SceneManager.LoadScene (SCENE_RESULT);
	}

	private void LoadSceneWithAnime (TweenCallback callback)
	{
		DOTween.Sequence ()
			.Join (this.gameObject.GetComponent<RectTransform> ().DOScale (Vector3.one * 1.5f, 0.5f))
			.Join (gameObject.GetComponent<CanvasGroup> ().DOFade (0.0f, 0.5f))
			.OnComplete (callback);
	}
}
