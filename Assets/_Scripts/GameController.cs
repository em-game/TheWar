using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//private instance variables
	private int _scoreValue;
	private int _livesValue;

	private Vector3 _playerSpawnPoint;

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
				Debug.Log ("here");
				this._endGame ();
			} else {
				this.LivesLabel.text = "LIVES: " + this._livesValue;
			}
		}
	}

	//public instance variables
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton;
	public GameObject player;

	// Use this for initialization
	void Start () {
		this._initialize ();

		Instantiate (this.player, this._playerSpawnPoint, Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}

	private void _endGame(){
		this.HighScoreLabel.text = "High Score : " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.HighScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
		this.LivesLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (false);
	}

	//public methods
	public void RestartButtonClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
