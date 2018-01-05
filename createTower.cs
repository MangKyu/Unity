using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTower : MonoBehaviour {

    public GameObject tower;
    public bool isClicked = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isClicked && Input.GetMouseButton(0))
        {
            crateTower();
        }
    }

    public void buttonClick()
    {
        isClicked = true;
    }

    void crateTower()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        GameObject newtower = (GameObject)Instantiate(tower) as GameObject;
        
        newtower.transform.position = new Vector2(offset.x,offset.y);
        newtower.GetComponent<SpriteRenderer>().enabled = true;
        isClicked = false;
    }
}
