using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryTower : MonoBehaviour {

    public bool isClicked;
    // Use this for initialization
    void Start () {
        isClicked = false;
    }
    // Update is called once per frame
    void Update () {
        if (isClicked)
        {
            destroytower();
        }
    }

    public void buttonClick()
    {
        isClicked = true;
    }

    void destroytower()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Tower")
                {
                    Destroy(hit.collider.gameObject);
                    isClicked = false;
                }
            }
        }
    }
}
