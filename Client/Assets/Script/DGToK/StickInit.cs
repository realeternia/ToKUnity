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

    public GameObject CommonStick;

    public GameObject TowerBase;

    // Use this for initialization
    void Start ()
    {
        GenerateLandscape();
    }

    private void GenerateLandscape()
    {
        for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                GameObject tickItem;
                var height = MathTool.GetRandom(7) + 1;
                tickItem = Instantiate(CommonStick, gameObject.transform);
                tickItem.transform.localScale = new Vector3(3, 3, 3);
                tickItem.transform.position = new Vector3(i*3, 0.5f + (float)height/2, j*3);

                GameObject subtickItem;
                if (height == 1)
                {
                    subtickItem = Instantiate(BlueStick, tickItem.transform);
                }
                else if (height == 7)
                {
                    subtickItem = Instantiate(GrayStick, tickItem.transform);
                }
                else
                {
                    subtickItem = Instantiate(GreenStick, tickItem.transform);
                }
             //   subtickItem.transform.localPosition = new Vector3(0, (float) height/10 + 0.1f, 0);
           //     subtickItem.transform.localScale = new Vector3(1, 0.01f, 1);

                if (MathTool.IsRandomInRange01(0.3f))
                {
                    var towerItem = Instantiate(TowerBase, tickItem.transform);
                  //  towerItem.transform.localPosition = new Vector3(0, (float)height / 10 + 0.1f, 0);
                  //  towerItem.transform.localScale = new Vector3(0.5f/3, 0.5f/5, 0.5f/3);
                }
            }
        }
    }

    // Update is called once per frame
	void Update () {
		
	}
}
