using System.Collections;
using System.Collections.Generic;
using NarlonLib.Math;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class StickInit : MonoBehaviour
{
    public GameObject GreenStick;
    public GameObject BlueStick;
    public GameObject GrayStick;

    // Use this for initialization
    void Start () {
	    for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                GameObject tickItem;
                var height = MathTool.GetRandom(7) + 1;
                if (height == 1)
                {
                    tickItem = Instantiate(BlueStick, gameObject.transform);
                }
                else if (height == 7)
                {
                    tickItem = Instantiate(GrayStick, gameObject.transform);
                }
                else
                {
                    tickItem = Instantiate(GreenStick, gameObject.transform);
                }
                tickItem.transform.localScale = new Vector3(3, height, 3);
                tickItem.transform.position = new Vector3(i*3,0.5f,j*3);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
