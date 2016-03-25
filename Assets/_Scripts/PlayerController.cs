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

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._gameController = GameObject.FindWithTag ("GameController").GetComponent("GameController") as GameController;

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
				} else {
					Instantiate (this.bulletImpact, hit.point, Quaternion.identity);
				}
			}
		}
	}

	public void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Enemy")){
			
			this._gameController.LivesValue -= 1;
		}
	}


}