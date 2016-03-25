/*
Source file name : GameController.cs
Author : Eunmi Han(300790610)
Date last Modified : Mar 25, 2016
Program Description : Control Scoring and ending
Revision History : 1.01 - Initial Setup
                   1.02 - Scoring
                   1.03 - ending
                   1.04 - Timer for gate                   
Last Modified by Eunmi Han
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//private instance variables
	private int _scoreValue;
	private int _livesValue;
	private int _enemyCount;
	private float _timeleft = 60.0f;

	private Vector3 _playerSpawnPoint;
	private Vector3 _gateSpawnPoint;


	//public access methods
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "SCORE: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {				
				this._endGame ();
			} else {
				this.LivesLabel.text = "LIVES: " + this._livesValue;
			}
		}
	}

	public int EnemyCount {
		get {
			return this._enemyCount;
		}

		set {
			this._enemyCount = value;
			if (this._enemyCount <= 0) {
				this._findGate ();
			} else {
				this.EnemyLabel.text = "Enemies : " + this._enemyCount;
			}
		}

	}


	//public instance variables
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Text EnemyLabel;
	public Text TimeLabel;
	public Button RestartButton;
	public GameObject player;
	public GameObject gate;

	// Use this for initialization
	void Start () {
		this._initialize ();

		Instantiate (this.player, this._playerSpawnPoint, Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this._enemyCount < 1) {
			this._timeleft -= Time.deltaTime;
			this.TimeLabel.text = "Time : " + Mathf.Round (this._timeleft);
			if (this._timeleft < 0) {
				
				this._endGame ();
			}
		}
	
	}

	//private methods 

	//Initial method
	private void _initialize(){
		this._playerSpawnPoint = new Vector3 (83f, 10f, 83f);
		this.ScoreValue = 0;
		this.LivesValue = 5;
		this.GameOverLabel.gameObject.SetActive (false);
		this.HighScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
		this.TimeLabel.gameObject.SetActive (false);
	}

	private void _endGame(){
		this.HighScoreLabel.text = "High Score : " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.GameOverLabel.text = "Game Over";
		this.HighScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
		this.LivesLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (false);
		this.EnemyLabel.gameObject.SetActive (false);
		this.TimeLabel.gameObject.SetActive (false);
	}



	private void _findGate(){

		this.EnemyLabel.text = "Find the Gate!!!!!";
		this.TimeLabel.gameObject.SetActive (true);
		int xPosition = Random.Range (80, 290);
		int zPosition = Random.Range (250, 30);
		this._gateSpawnPoint = new Vector3 (xPosition, 7, zPosition);

			Instantiate (this.gate, this._gateSpawnPoint, Quaternion.identity);
	}

	//public methods
	public void RestartButtonClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void _wonGame(){
		this.HighScoreLabel.text = "High Score : " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.GameOverLabel.text = "You won!!";
		this.HighScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
		this.LivesLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (false);
		this.EnemyLabel.gameObject.SetActive (false);
		this.TimeLabel.gameObject.SetActive (false);
	}
}
