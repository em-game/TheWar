using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform enemy;
	public Transform player;

	private float moveSpeed = 4f;
	private float rotationSpeed = 5f;


	// Use this for initialization
	void Start () {


	}

	void Awake(){
		this.enemy = gameObject.GetComponent<Transform>(); 

	}
	
	// Update is called once per frame
	void Update () {

		//Set a minimum distance, make enemy keep distance between player and enemy
		if (Vector3.Distance (enemy.position, this.player.transform.position) >= 5) {

			enemy.rotation = Quaternion.Slerp (enemy.rotation, Quaternion.LookRotation (this.player.transform.position - enemy.position), rotationSpeed * Time.deltaTime);


			enemy.position += new Vector3 (enemy.forward.x * moveSpeed * Time.deltaTime, 0 * Time.deltaTime, enemy.forward.z * moveSpeed * Time.deltaTime);
		}

	}
}
