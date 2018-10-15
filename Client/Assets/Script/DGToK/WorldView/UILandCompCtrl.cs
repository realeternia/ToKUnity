using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILandCompCtrl : MonoBehaviour
{
    public string Name;
    public int Val;

	// Use this for initialization
	void Start ()
	{
	    transform.Find("Text").GetComponent<Text>().text = Name;
        transform.Find("Value").GetComponent<Text>().text = Val.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVal(int val)
    {
        Val = val;
        transform.Find("Value").GetComponent<Text>().text = Val.ToString();
    }
}
