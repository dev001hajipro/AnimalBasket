using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(PolygonCollider2D))]
public class BallBehaviour : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private PolygonCollider2D c2d;
	private bool isPicking = false;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		c2d = GetComponent<PolygonCollider2D> ();
	}

	void Update ()
	{
		#if (UNITY_ANDROID || UNITY_IOS)
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			var touchPos = Camera.main.ScreenToWorldPoint (touch.position);
			switch (touch.phase) {
			case TouchPhase.Began:
				if (Physics2D.OverlapPoint (touchPos) == this.c2d) {
					isPicking = true;
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
		if (Input.GetMouseButtonDown (0)) {
			var pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (Physics2D.OverlapPoint (pos) == this.c2d) {
				isPicking = true;
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
