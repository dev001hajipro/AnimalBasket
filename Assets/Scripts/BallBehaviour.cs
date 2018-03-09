using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(PolygonCollider2D))]
public class BallBehaviour : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private bool isPicking = false;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		#if (UNITY_ANDROID || UNITY_IOS)
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position);
			var ray = Camera.main.ScreenPointToRay (touch.position);
			switch (touch.phase) {
			case TouchPhase.Began:
				if (Physics2D.OverlapPoint (touchPos)) {
					RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 100f);
					// AnimalObjectPoolで生成する際に、コライダーを削除、新規追加
					// して、スプライトにあったコライダーにしている。
					// そのため、Start()メソッドでGetComponentで取得した場合、
					// 常にhit.colliderと一致しなくなる。
					if (hit.collider == GetComponent<PolygonCollider2D> ()) {
						isPicking = true;
					}
				}
				break;
			case TouchPhase.Moved:
				if (isPicking) {
					//rb2d.MovePosition (touchPos - offset);
					const float force = 15f;
					rb2d.velocity = (touchPos - transform.position) * force;
				}
				break;
			case TouchPhase.Ended:
				isPicking = false;
				break;
			}
		}
		#else
		if (!isPicking && Input.GetMouseButtonDown (0)) {
			var pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			pos.z = 0f;
			if (Physics2D.OverlapPoint (pos)) {
				Debug.Log (ray.direction);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 100f);
				if (hit.collider == GetComponent<PolygonCollider2D> ()) {
					Debug.Log ("pickup!!!");
					isPicking = true;
				}
			}
		}
		if (isPicking) {
			var pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.z = 0;
			const float force = 5f;
			rb2d.velocity = (pos - transform.position) * force;
		}

		if (isPicking && Input.GetMouseButtonUp (0)) {
			isPicking = false;
		}
		#endif
	}
}
