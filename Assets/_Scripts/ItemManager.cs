/*
Source file name : ItemManager.cs
Author : Eunmi Han(300790610)
Date last Modified : Mar 25, 2016
Program Description : control enemy
Revision History : 1.01 - Initial Setup
				   1.02 - Add bottle
                                      
Last Modified by Eunmi Han
*/

using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {
	//public instance variables
	public GameObject item;
	public float spawnTime;
	public Transform[] spawnPoint;

	//private instance variables
	private int itemCount;
	private int start =1;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		itemCount = Random.Range (10, 20);	
		Debug.Log ("itemCount : " + itemCount);
	
	}
	
	// Update is called once per frame
	void Spawn () {
		//limit the count of enemy
		if( start <= itemCount){
			// enemy's position ramdomly
			int xPosition = Random.Range (80, 290);
			int zPosition = Random.Range (250, 30);

			//find a random index
			int spawnPointIndex = Random.Range (0, spawnPoint.Length);

			spawnPoint [spawnPointIndex].position = new Vector3 (xPosition, 5.3f, zPosition);

			//create enemy
			Instantiate(item, spawnPoint[spawnPointIndex].position,spawnPoint[spawnPointIndex].rotation);
			start++;
		}

	}
}
