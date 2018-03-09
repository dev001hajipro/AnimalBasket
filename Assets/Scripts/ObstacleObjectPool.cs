using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleObjectPool : MonoBehaviour
{

	public GameObject obstaclePrefab;

	private GameObject[] pool;

	// 画面外
	public Vector2 objectPosition = new Vector2 (20, 20);

	public int poolSize = 5;
	private int poolIndex = 0;

	public float spawnRate = 4f;
	public float timeSinceLastSpawned;

	public int xPositionMin = -2;
	public int xPositionMax = 2;

	public float spawnYPosition = 6f;


	void Start ()
	{
		pool = Enumerable.Range (0, poolSize)
			.Select (i => (GameObject)Instantiate (obstaclePrefab, objectPosition, Quaternion.identity))
			.ToArray ();
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
