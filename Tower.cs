using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public bool isClicked = false;
    void Start()
    {

    }

    void Update()
    {
        Turning2();        
    }

    void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        mousePos -= transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        UnityEngine.Debug.Log(mousePos + " " + transform.position + Screen.width + "::" + Screen.height);
    }

    void Turning2()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        // UnityEngine.Debug.Log(screenPoint + " ::::" + offset + " ::::" +Input.mousePosition );

        float angle = Mathf.Atan2(-(offset.y), -(offset.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

   
}
