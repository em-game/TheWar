/*
Source file name : EnemyManager.cs
Author : Eunmi Han(300790610)
Date last Modified : Mar 25, 2016
Program Description : control enemy
Revision History : 1.01 - Initial Setup
                   1.02 - create enemy ramdomly                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour 
{
	//public instance variables
	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoint;
	public GameController GameController;

	//private instance variables
	private int enemyCount;
	private int start =1;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemyCount = Random.Range (10, 30);	
		this.GameController.EnemyCount = enemyCount;
	}

	// Update is called once per frame
	void Spawn () {
		//limit the count of enemy
		if( start <= enemyCount){
			// enemy's position ramdomly
			int xPosition = Random.Range (80, 290);
			int zPosition = Random.Range (250, 30);

		//find a random index
		int spawnPointIndex = Random.Range (0, spawnPoint.Length);


		spawnPoint [spawnPointIndex].position = new Vector3 (xPosition, 5, zPosition);
		
		//create enemy
		Instantiate(enemy, spawnPoint[spawnPointIndex].position,spawnPoint[spawnPointIndex].rotation);
		start++;
		}
	
	}
}
