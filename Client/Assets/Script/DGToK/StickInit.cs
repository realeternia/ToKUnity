using System.Collections;
using System.Collections.Generic;
using NarlonLib.Math;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class StickInit : MonoBehaviour
{
    public GameObject GreenStick;
    public GameObject BlueStick;

    // Use this for initialization
    void Start () {
	    for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                GameObject tickItem;
                if (MathTool.IsRandomInRange01(0.15f))
                {
                    tickItem = Instantiate(BlueStick, gameObject.transform);
                    tickItem.transform.localScale = new Vector3(3, 1, 3);
                }
                else
                {
                    tickItem = Instantiate(GreenStick, gameObject.transform);
                    tickItem.transform.localScale = new Vector3(3, MathTool.GetRandom(7), 3); //1-7的高度
                }
                tickItem.transform.position = new Vector3(i*3,0.5f,j*3);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
