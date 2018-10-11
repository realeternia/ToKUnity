using System.Collections;
using System.Collections.Generic;
using NarlonLib.Math;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class StickInit : MonoBehaviour
{
    public class LandData
    {
        public GameObject StickItem;
    }

    public GameObject GreenStick;
    public GameObject BlueStick;
    public GameObject GrayStick;

    public GameObject CommonStick;

    public GameObject TowerBase;

    private Dictionary<int, LandData> landDict = new Dictionary<int, LandData>();

    // Use this for initialization
    void Start ()
    {
        GenerateLandscape();
    }

    private void GenerateLandscape()
    {
        List<int> canTowerLandList = new List<int>();
        for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                GameObject tickItem;
                var height = MathTool.GetRandom(7) + 1;
                tickItem = Instantiate(CommonStick, gameObject.transform);
                tickItem.transform.localScale = new Vector3(3, 3, 3);
                tickItem.transform.position = new Vector3(i*3, 0.5f + (float)height/2, j*3);
                var itemId = (i + 11) * 1000 + j + 11;
                landDict[itemId] = new LandData { StickItem = tickItem };

                tickItem.GetComponent<LandInfo>().Id = itemId;

                if (height == 1)
                {
                    Instantiate(BlueStick, tickItem.transform);
                }
                else if (height == 7)
                {
                    Instantiate(GrayStick, tickItem.transform);
                }
                else
                {
                    Instantiate(GreenStick, tickItem.transform);
                    canTowerLandList.Add(itemId); //只有平地可以出现城堡
                }
            }
        }

        var towerList = NLRandomPicker<int>.RandomPickN(canTowerLandList, 5);
        foreach (var towerId in towerList)
        {
            Instantiate(TowerBase, landDict[towerId].StickItem.transform);
        }
    }

    // Update is called once per frame
	void Update () {
		
	}
}
