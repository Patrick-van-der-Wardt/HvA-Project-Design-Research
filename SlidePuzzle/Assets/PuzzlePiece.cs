using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {

	public int index;
	public int puzzleSize;

	private Vector3 correctPos;
	private Vector3 Small1;
	private Vector3 Small2;
	private Vector3 Small3;
	private Vector3 Small4;
	private Vector3 Small5;
	private Vector3 Small6;
	private Vector3 Small7;
	private Vector3 Small8;
	private Vector3 Small9;

	private Vector3 Normal1;
	private Vector3 Normal2;
	private Vector3 Normal3;
	private Vector3 Normal4;
	private Vector3 Normal5;
	private Vector3 Normal6;
	private Vector3 Normal7;
	private Vector3 Normal8;
	private Vector3 Normal9;
	private Vector3 Normal10;
	private Vector3 Normal11;
	private Vector3 Normal12;
	private Vector3 Normal13;
	private Vector3 Normal14;
	private Vector3 Normal15;
	private Vector3 Normal16;

	public bool correctCheck;

	// Use this for initialization
	void Start () {
			if(puzzleSize==9){
				if(index==1)
				{
					correctPos = new Vector3(0-renderer.bounds.size.x,0+renderer.bounds.size.y,0);
				}
				if(index==2)
				{
					correctPos = new Vector3(0,0+renderer.bounds.size.y,0);
				}
				if(index==3)
				{
					correctPos = new Vector3(0+renderer.bounds.size.x,0+renderer.bounds.size.y,0);
				}
				if(index==4)
				{
					correctPos = new Vector3(0-renderer.bounds.size.x,0,0);
				}
				if(index==5)
				{
					correctPos = new Vector3(0,0,0);
				}
				if(index==6)
				{
					correctPos = new Vector3(0+renderer.bounds.size.x,0,0);
				}
				if(index==7)
				{
					correctPos = new Vector3(0-renderer.bounds.size.x,0-renderer.bounds.size.y,0);
				}
				if(index==8)
				{
					correctPos = new Vector3(0,0-renderer.bounds.size.y,0);
				}
			}
		else if(puzzleSize==16){
			if(index==1)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x-renderer.bounds.size.x/2,0+renderer.bounds.size.y+renderer.bounds.size.y/2,0);
			}
			if(index==2)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x/2,0+renderer.bounds.size.y+renderer.bounds.size.y/2,0);
			}
			if(index==3)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x/2+renderer.bounds.size.x,0+renderer.bounds.size.y+renderer.bounds.size.y/2,0);
			}
			if(index==4)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x+renderer.bounds.size.x/2-renderer.bounds.size.x,0+renderer.bounds.size.y+renderer.bounds.size.y/2,0);
			}
			if(index==5)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x-renderer.bounds.size.x/2,0+renderer.bounds.size.y/2,0);
			}
			if(index==6)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x/2,0+renderer.bounds.size.y/2,0);
			}
			if(index==7)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x/2,0+renderer.bounds.size.y/2,0);
			}
			if(index==8)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x+renderer.bounds.size.x/2,0+renderer.bounds.size.y/2,0);
			}
			if(index==9)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x-renderer.bounds.size.x/2,0-renderer.bounds.size.y/2,0);
			}
			if(index==10)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x/2,0-renderer.bounds.size.y/2,0);
			}
			if(index==11)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x/2,0-renderer.bounds.size.y/2,0);
			}
			if(index==12)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x+renderer.bounds.size.x/2,0-renderer.bounds.size.y/2,0);
			}
			if(index==13)
			{
				correctPos = new Vector3(0-renderer.bounds.size.x-renderer.bounds.size.x/2,0-renderer.bounds.size.y-renderer.bounds.size.y/2,0);
			}
			if(index==14)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x,0-renderer.bounds.size.y-renderer.bounds.size.y/2,0);
			}
			if(index==15)
			{
				correctPos = new Vector3(0+renderer.bounds.size.x+renderer.bounds.size.x/2,0-renderer.bounds.size.y-renderer.bounds.size.y/2,0);
			}
		}
		
		
		if (correctPos == transform.position)
		{
			correctCheck = true;
			PuzzleStart.cleared +=1;
		}
		else{correctCheck = false;}
	}
	void OnMouseDown(){

		//Up
		if (!Physics2D.OverlapCircle (new Vector2(transform.position.x, transform.position.y+transform.lossyScale.y), 0.1f)) {
			transform.Translate(0,renderer.bounds.size.y,0);
			}
		//Down
		else if (!Physics2D.OverlapCircle (new Vector2(transform.position.x, transform.position.y-transform.lossyScale.y), 0.1f)) {
			transform.Translate(0,-renderer.bounds.size.y,0);
			}
		//Left
		else if (!Physics2D.OverlapCircle (new Vector2(transform.position.x-transform.lossyScale.x, transform.position.y), 0.1f)) {
			transform.Translate(-renderer.bounds.size.x,0,0);
		}
		//Right
		else if (!Physics2D.OverlapCircle (new Vector2(transform.position.x+transform.lossyScale.x, transform.position.y), 0.1f)) {
			transform.Translate(renderer.bounds.size.x,0,0);
		}

		if (transform.position == correctPos){
			correctCheck = true;
			PuzzleStart.cleared +=1;
		}
		else if (transform.position != correctPos && correctCheck == true){
			correctCheck = false;
			PuzzleStart.cleared -=1;
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
