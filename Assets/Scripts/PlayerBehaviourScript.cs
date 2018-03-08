using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{

	private Vector2 directon;
	private Rigidbody2D rb2d;
	public float force = 10f;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		directon = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		rb2d.velocity = directon * force;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("plus1")) {
			
		}

		switch (other.gameObject.tag) {
		case "plus1":
			TimeLeftScript.timeLeft += 1f;
			other.gameObject.SetActive (false);
			break;
		case "minus2":
			TimeLeftScript.timeLeft -= 2f;
			other.gameObject.SetActive (false);
			break;
		}
	}
}
