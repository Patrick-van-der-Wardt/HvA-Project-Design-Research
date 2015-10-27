using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileScript : MonoBehaviour {

	public Vector2 pos;
	public ControllerScript controller;
	public int index;
	
	// Use this for initialization
	void Start () {
		Debug.Log( gameObject.transform.GetChild(0).GetComponent<RectTransform>().rect );
		Debug.Log( gameObject.transform.GetChild(0).GetComponent<Image>().sprite.rect );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnMouseDown () {
		int x = (int)pos.x;
		int y = (int)pos.y;
		if(x>0 && controller.grid[x-1,y] == null)
		{
			controller.grid[x,y] = null;
			controller.grid[x-1,y] = this.gameObject;
			this.gameObject.transform.position = controller.positions[x-1,y];
			pos = new Vector2(x-1,y);
			controller.Finish();
		}
		else if(y>0 && controller.grid[x,y-1] == null)
		{
			controller.grid[x,y] = null;
			controller.grid[x,y-1] = this.gameObject;
			this.gameObject.transform.position = controller.positions[x,y-1];
			pos = new Vector2(x,y-1);
			controller.Finish();
		}
		else if(x<2 && controller.grid[x+1,y] == null)
		{
			controller.grid[x,y] = null;
			controller.grid[x+1,y] = this.gameObject;
			this.gameObject.transform.position = controller.positions[x+1,y];
			pos = new Vector2(x+1,y);
			controller.Finish();
		}
		else if(y<2 && controller.grid[x,y+1] == null)
		{
			controller.grid[x,y] = null;
			controller.grid[x,y+1] = this.gameObject;
			this.gameObject.transform.position = controller.positions[x,y+1];
			pos = new Vector2(x,y+1);
			controller.Finish();
		}
        }
}
