/*
Source file name : PlayerController.cs
Author : Eunmi Han(300790610)
Date last Modified : Mar 25, 2016
Program Description : player controll
Revision History : 1.01 - Initial Setup
                   1.02 - shooting
                   1.03 - scoring  
                   1.04 - add audio
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//PUBLIC MEMBER VARIABLES
	public Transform flashPoint;
	public GameObject muzzleFlash;
	public GameObject bulletImpact;


	//private instance variables
	private Transform _transform;
	private GameController _gameController;
	private AudioSource[] _audio;
	private AudioSource _Groan;
	private AudioSource _ouch;
	private AudioSource _item;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._gameController = GameObject.FindWithTag ("GameController").GetComponent("GameController") as GameController;
		this._audio = gameObject.GetComponents<AudioSource> ();
		this._Groan = this._audio [0];	
		this._ouch = this._audio [1];
		this._item = this._audio [2];

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (this.muzzleFlash, flashPoint.position, Quaternion.identity);

			RaycastHit hit; // stores information from the Ray;

			if (Physics.Raycast (this._transform.position, this._transform.forward, out hit, 50f)) {
				if (hit.transform.gameObject.CompareTag ("Enemy")) {
					
					Destroy(hit.transform.gameObject);
					this._gameController.ScoreValue += 75;
					this._gameController.EnemyCount -= 1;
					this._Groan.Play ();
				} else {
					Instantiate (this.bulletImpact, hit.point, Quaternion.identity);
				}
			}
		}


	}

	public void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Enemy")){

			this._gameController.LivesValue -= 1;
			this._ouch.Play ();
		}

		if (other.gameObject.CompareTag ("Gate")) {
			//bonus score
			this._gameController.ScoreValue += 1000;
			this._gameController._wonGame ();
		}

		if (other.gameObject.CompareTag ("Item")) {
			//bonus score
			this._gameController.ScoreValue += 20;
			this._item.Play ();
			Destroy (other.gameObject);
		}
	}



}