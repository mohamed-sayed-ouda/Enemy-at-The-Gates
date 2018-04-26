using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] GameObject player;
	[SerializeField] GameObject[] spawnPoints;
	[SerializeField] GameObject tanker;
	[SerializeField] GameObject ranger;
	[SerializeField] GameObject soldier;

	[SerializeField] Text LevelText;

	private bool gameOver = false;
	private int currentLevel;
	private int finalLevel=20;
	private float generatedSpawnTime = 1;
	private float currentSpawnTime = 0;
	private GameObject newEnemy;


	private List<EnemyHealth> enemies = new List<EnemyHealth> ();
	private List<EnemyHealth> killedEnemies = new List<EnemyHealth> ();

	public void RegisterEnemy(EnemyHealth enemy) {
		enemies.Add (enemy);
	}

	public void KilledEnemy(EnemyHealth enemy) {
		killedEnemies.Add (enemy);
	}


	public bool GameOver {
		get {return gameOver; }
	}

	public GameObject Player {
		get { return player; }
	}
		

	void Awake() {

		if (instance == null) {
			instance = this;}
		}

	// Use this for initialization
	void Start () {


		StartCoroutine (spawn ());
		currentLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {

		currentSpawnTime += Time.deltaTime;
	}

	public void PlayerHit(int currentHP) {

		if (currentHP > 0) {
			gameOver = false;
		} else {
			gameOver = true;
		}
	}

	IEnumerator spawn() {

		if (currentSpawnTime > generatedSpawnTime) {
			currentSpawnTime = 0;

			if (enemies.Count < currentLevel) {

				int randomNumber = Random.Range (0, spawnPoints.Length - 1);
				GameObject spawnLocation = spawnPoints [randomNumber];
				int randomEnemy = Random.Range (0, 3);
				if (randomEnemy == 0) {
					newEnemy = Instantiate (soldier) as GameObject;
				} else if (randomEnemy == 1) {
					newEnemy = Instantiate (ranger) as GameObject;
				} else if (randomEnemy == 2) {
					newEnemy = Instantiate (tanker) as GameObject;
				}

				newEnemy.transform.position = spawnLocation.transform.position;
					
		  }

			if (killedEnemies.Count == currentLevel && currentLevel != finalLevel) {

				enemies.Clear ();
				killedEnemies.Clear ();

				yield return new WaitForSeconds (3f);
				currentLevel++;
				LevelText.text = "Level " + currentLevel;
			}

			/*if (killedEnemies.Count == finalLevel) {
				StartCoroutine (endGame ("Victory!"));
			}*/
		}

		yield return null;
		StartCoroutine (spawn ());
	}

}
