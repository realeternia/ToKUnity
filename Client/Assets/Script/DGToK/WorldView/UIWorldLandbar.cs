using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIWorldLandbar : MonoBehaviour
{
    public static UIWorldLandbar Instance { get; private set; }

    public GameObject ResComp;

    private UILandCompCtrl compCommerce; //商业;
    private UILandCompCtrl compAgriculture; //农业
    private UILandCompCtrl compIndustryL; //轻工业
    private UILandCompCtrl compIndustryH; //重工业

    private UILandCompCtrl compPopulation; //人口
    private UILandCompCtrl compDefence; //防御
    private UILandCompCtrl compFood; //食物

    void Start()
    {
        Instance = this;
        {
            var goldItem = Instantiate(ResComp, transform);
            compCommerce = goldItem.GetComponent<UILandCompCtrl>();
            compCommerce.Name = "商业";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compAgriculture = foodItem.GetComponent<UILandCompCtrl>();
            compAgriculture.Name = "农业";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compIndustryL = foodItem.GetComponent<UILandCompCtrl>();
            compIndustryL.Name = "纺织";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compIndustryH = foodItem.GetComponent<UILandCompCtrl>();
            compIndustryH.Name = "锻造";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compPopulation = foodItem.GetComponent<UILandCompCtrl>();
            compPopulation.Name = "人口";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compDefence = foodItem.GetComponent<UILandCompCtrl>();
            compDefence.Name = "防御";
        }

        {
            var foodItem = Instantiate(ResComp, transform);
            compFood = foodItem.GetComponent<UILandCompCtrl>();
            compFood.Name = "食物";
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void SetLandId(int landId)
    {
        var landData = LandManager.Instance.GetLand(landId);
        print(landId + ":" + landData.Agriculture);
        compAgriculture.SetVal( landData.Agriculture);
        compCommerce.SetVal(landData.Commerce);
        compIndustryL.SetVal(landData.IndustryL);
        compIndustryH.SetVal(landData.IndustryH);
        compDefence.SetVal(landData.Defence);
        compPopulation.SetVal(landData.Population);
        compFood.SetVal(landData.Food);
    }
}
