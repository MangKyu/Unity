using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTower : MonoBehaviour
{
    public GameObject tower;
   
    void Start()
    {
        maketower();
    }

    void Update()
    {

    }

    void maketower()
    {
        GameObject newtower = (GameObject)Instantiate(tower) as GameObject;
        float x = Random.Range(-25, 25);
        float y = Random.Range(-25, 25);
        newtower.transform.position = new Vector2(x, y);
    }

    void maketower2()
    {
        GameObject myRoadInstance =
            Instantiate(Resources.Load("tower"),
            new Vector3(5, 5, 0),
            Quaternion.identity) as GameObject;
        Instantiate(Resources.Load("tower"), new Vector3(3, 3, 0), Quaternion.identity);

    }
}
