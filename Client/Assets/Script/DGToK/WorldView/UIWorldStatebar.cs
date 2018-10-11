using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIWorldStatebar : MonoBehaviour
{
    public GameObject ResComp;

    void Start()
    {
        {
            var goldItem = Instantiate(ResComp, transform);
            //    goldItem.transform.localPosition = new Vector3(80,0,0);
            var goldRes = goldItem.GetComponent<UIResCompCtrl>();
            goldRes.Icon = "buf0";
            goldRes.Name = "金钱";
            goldRes.Val = 120;
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            foodItem.transform.localPosition = new Vector3(foodItem.transform.localPosition.x + 150, 0, 0);
            var foodRes = foodItem.GetComponent<UIResCompCtrl>();
            foodRes.Icon = "buf1";
            foodRes.Name = "粮食";
            foodRes.Val = 9999;
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            foodItem.transform.localPosition = new Vector3(foodItem.transform.localPosition.x + 150*2, 0, 0);
            var foodRes = foodItem.GetComponent<UIResCompCtrl>();
            foodRes.Icon = "buf2";
            foodRes.Name = "武将";
            foodRes.Val = 7;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
