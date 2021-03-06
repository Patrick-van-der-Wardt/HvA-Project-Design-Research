﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ControllerScript : MonoBehaviour {

	System.Random random = new System.Random();
	public GameObject tile;
	public Vector2 size = new Vector2(3,3);
	public GameObject[,] tiles;
	public GameObject[,] grid;
	public Vector2[,] positions;
	bool shuffled = false;
	public Vector2 imgSize;
	float yFactor;
	
	// Use this for initialization
	void Start () {
		
		tiles = new GameObject[(int)size.x,(int)size.y];
		grid = new GameObject[(int)size.x,(int)size.y];
		positions = new Vector2[(int)size.x,(int)size.y];
		imgSize = new Vector2(tile.transform.GetChild(0).GetComponent<Image>().sprite.rect.width, tile.transform.GetChild(0).GetComponent<Image>().sprite.rect.height);
		yFactor = imgSize.y / imgSize.x * 100.0f;
		
		List<GameObject> list = new List<GameObject>();
		
		for(int i = 0; i < size.x; i++)
		{
			for(int j = 0; j < size.y; j++)
			{
				positions[i,j] = new Vector2(i * 100.0f - 150.0f, j * yFactor - yFactor * 1.5f);
				if(i!=2 || j!=2)
				{
					tiles[i,j] = (GameObject)Instantiate(tile);
					
					TileScript ts = tiles[i,j].GetComponent<TileScript>();
					ts.controller = this;
					ts.index = j+3*i;
					ts.pos = new Vector2(i,j);
					
					tiles[i,j].transform.GetChild(0).transform.position = new Vector2(i * -100.0f, j * -yFactor);
					tiles[i,j].transform.position = positions[i,j];
					tiles[i,j].GetComponent<BoxCollider2D>().size = new Vector2( 100.0f, yFactor);
					tiles[i,j].GetComponent<BoxCollider2D>().offset = new Vector2( 50.0f, yFactor/2);
					tiles[i,j].GetComponent<RectTransform>().sizeDelta = new Vector2( 100.0f, yFactor);
					tiles[i,j].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2( 100.0f * size.x, yFactor * size.y);
					
					grid[i,j] = tiles[i,j];
					list.Add( tiles[i,j] );
				}
			}
		}
		
		for(int i = 0; i < 10000; i++)
		{
			int r = random.Next(0, list.Count-1);
			list[r].GetComponent<TileScript>().OnMouseDown();
		}
		shuffled = true;
			
	}
	
	//Checks if all the pieces are in the right place;
	public void Finish () {
		if(shuffled)
		{
			List<TileScript> iList = new List<TileScript>();
			
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if(grid[i,j] != null)
						iList.Add(grid[i,j].GetComponent<TileScript>());
				}
			}
			
			int inv = 0;
			
			for(int i = 0; i < iList.Count-1; i++)
			{
				for(int j = i+1; j < iList.Count; j++)
				{
					if(iList[i].index > iList[j].index)
						inv++;
				}
			}
			
			Debug.Log(inv);
			
			bool finish = true;
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					if(grid[i,j] != tiles[i,j])
					{
						finish = false;
						break;
					}
				}
			}
			if(finish)
			{
				int i = 2;
				int j = 2;
				tiles[i,j] = (GameObject)Instantiate(tile);
					
				TileScript ts = tiles[i,j].GetComponent<TileScript>();
				ts.controller = this;
				ts.index = j+3*i;
				ts.pos = new Vector2(i,j);
				
				tiles[i,j].transform.GetChild(0).transform.position = new Vector2(i * -100.0f, j * -yFactor);
				tiles[i,j].transform.position = positions[i,j];
				tiles[i,j].GetComponent<BoxCollider2D>().size = new Vector2( 100.0f, yFactor);
				tiles[i,j].GetComponent<BoxCollider2D>().offset = new Vector2( 50.0f, yFactor/2);
				tiles[i,j].GetComponent<RectTransform>().sizeDelta = new Vector2( 100.0f, yFactor);
				tiles[i,j].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2( 100.0f * size.x, yFactor * size.y);
				
				grid[i,j] = tiles[i,j];
				
				StartCoroutine("Reload");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Creates the Squares
	void Create () {
		
	}
	
	IEnumerator Reload () {
		yield return new WaitForSeconds(3);
		Application.LoadLevel(0);
	}
}
