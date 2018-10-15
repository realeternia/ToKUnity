using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudLand : MonoBehaviour
{
    public GameObject BindObj;
    public Vector3 Offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var pos = Camera.main.WorldToScreenPoint(BindObj.transform.position + Offset);
	    transform.position = pos;
	    var wBound = Screen.width/8;
        var hBound = Screen.height / 8;
        if (transform.position.x < wBound || transform.position.x > Screen.width-wBound || transform.position.y < hBound || transform.position.y > Screen.height - hBound)
        {
            GetComponent<Text>().fontSize = 18; //在屏幕边缘缩小
        }
        else
        {
            GetComponent<Text>().fontSize = 24;
        }
	}
}
