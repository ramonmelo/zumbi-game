using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float SpawnRate = 1.0f;

	void Start()
	{
		StartCoroutine(SpawnEnemy());
	}

	private IEnumerator SpawnEnemy()
	{
		while(true)
		{
			yield return new WaitForSeconds(SpawnRate);
			Instantiate(enemyPrefab, transform.position, transform.rotation);
		}
	}
}