using System.Collections.Generic;
using NarlonLib.Math;
using UnityEngine;

public class LandManager
{
    public class LandData
    {
        public GameObject StickItem;

        public int Commerce; //商业;
        public int Agriculture; //农业
        public int IndustryL; //轻工业
        public int IndustryH; //重工业

        public int Population; //人口
        public int Defence; //防御
        public int Food; //食物
    }

    private static LandManager instance;
    public static LandManager Instance { get { return instance ?? (instance = new LandManager()); } }

    private Dictionary<int, LandData> landDict = new Dictionary<int, LandData>();

    public void AddLand(int id, LandData data)
    {
        landDict[id] = data;
        data.Commerce = MathTool.GetRandom(10, 1000);
        data.Agriculture = MathTool.GetRandom(35, 60);
        data.IndustryL = MathTool.GetRandom(0, 10);
        data.IndustryH = MathTool.GetRandom(0, 2);
        data.Population = MathTool.GetRandom(0, 10);
        data.Defence = 0;
        data.Food = MathTool.GetRandom(0, 100);
    }

    public LandData GetLand(int id)
    {
        return landDict[id];
    }
}