using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResCompCtrl : MonoBehaviour
{
    public string Name;
    public string Icon;
    public int Val;
    public Image Image;

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(PicLoader.Instance.Load(Image, string.Format("Image/Icon/{0}.png", Icon)));
	    transform.Find("Text").GetComponent<Text>().text = Name;
        transform.Find("Value").GetComponent<Text>().text = Val.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
