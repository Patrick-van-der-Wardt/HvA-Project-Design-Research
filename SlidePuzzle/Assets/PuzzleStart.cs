using UnityEngine;
using System.Collections;

public class PuzzleStart : MonoBehaviour {
	static public int cleared;
	public Transform full;
	public int test;
	public bool won;
	public bool wonDone;


	// Use this for initialization
	void Start () {
		won = false;
		wonDone = false;

	}

		
	void Update () {
		test = cleared;
		if(cleared == 8){
			won = true;
		}
		else {
			won = false;
		}
		if (won == true && wonDone == false)
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag("PuzzlePiece");
			foreach(GameObject go in gos)
				Destroy(go);
			Instantiate(full,new Vector3(0,0,0),Quaternion.identity);
			wonDone = true;
		}

	}
}
