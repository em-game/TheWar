/*
Source file name : Enemy.cs
Author : Eunmi Han(300790610)
Date last Modified : Mar 25, 2016
Program Description : enemyAI
Revision History : 1.01 - Initial Setup
                   1.02 - Chase the player                   
Last Modified by Eunmi Han
*/

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//public instance variables

	public float speed;

	//private instance variables
	private Transform _transform; 
	private GameObject _player;


	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();	
		this._player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		//Check the distance between player and enemies...
		if (Vector3.Distance (this._transform.position, this._player.transform.position) >= 2 && Vector3.Distance (this._transform.position, this._player.transform.position) <= 60) {

			float step = speed * Time.deltaTime;
		
			this._transform.rotation = Quaternion.Slerp (this._transform.rotation, Quaternion.LookRotation (this._player.transform.position - this._transform.position), 3f * Time.deltaTime);

			this._transform.position = Vector3.MoveTowards (this._transform.position, new Vector3 (this._player.transform.position.x, 5, this._player.transform.position.z), step);
		}
	
	}
}
