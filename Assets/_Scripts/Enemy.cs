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

		float step = speed * Time.deltaTime;
		
		//this._transform.rotation = Quaternion.Slerp (this._transform.rotation, Quaternion.LookRotation (this._player.transform.position - this._transform.position), 3f * Time.deltaTime);
		this._transform.rotation = Quaternion.Slerp (this._transform.rotation, Quaternion.LookRotation (new Vector3(this._player.transform.position.x,5,this._player.transform.position.x) - this._transform.position), 3f * Time.deltaTime);
		//this._transform.position = Vector3.MoveTowards (this._transform.position, this._player.transform.position, step);
		this._transform.position = Vector3.MoveTowards (this._transform.position, new Vector3(this._player.transform.position.x,5,this._player.transform.position.z), step);
	
	}
}
