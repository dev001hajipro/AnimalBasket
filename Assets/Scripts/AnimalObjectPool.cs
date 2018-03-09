using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimalObjectPool : MonoBehaviour
{

	public GameObject prefab;
	public Sprite[] sprites;

	private GameObject[] pool;

	// 画面外
	public Vector2 objectPosition = new Vector2 (0, 16);

	public int poolSize = 20;
	private int poolIndex = 0;

	public float spawnRate = 2f;
	private float timeSinceLastSpawned;

	public int xPositionMin = -2;
	public int xPositionMax = 2;

	public float spawnYPosition = 6f;


	void Start ()
	{
		pool = Enumerable.Range (0, poolSize)
			.Select (i => (GameObject)Instantiate (prefab, objectPosition, Quaternion.identity))
			.ToArray ();
		pool = pool.Select (x => {
			Destroy (x.GetComponent<PolygonCollider2D> ());
			x.GetComponent<SpriteRenderer> ().sprite = sprites [(int)Random.Range (0, sprites.Length)];
			var polygonCollider2D = x.AddComponent<PolygonCollider2D> ();
			var m = new PhysicsMaterial2D ();
			m.bounciness = 0.8f;
			m.friction = 0.4f;
			polygonCollider2D.sharedMaterial = m;
			return x;
		}).ToArray ();
	}

	void Update ()
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (timeSinceLastSpawned > spawnRate) {
			timeSinceLastSpawned = 0f;
			Spawn ();
			poolIndex = ++poolIndex % poolSize;
		}
	}

	private void Spawn ()
	{
		float spawnXPosition = Random.Range (xPositionMin, xPositionMax);
		pool [poolIndex].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
	}
}
