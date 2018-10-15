using System;
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

    public GameObject SelectEffType;
    public GameObject HudLand;
    public GameObject UICanvas;

    private Camera mainCamera;

    private Vector3 cameraPos;
    private int selectLandId;
    private GameObject selectEff;

    // Use this for initialization
    void Start ()
    {
        GenerateLandscape();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = mainCamera.transform.position;
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
                LandManager.Instance.AddLand(itemId, new LandManager.LandData {StickItem = tickItem});

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
            var tower = Instantiate(TowerBase, LandManager.Instance.GetLand(towerId).StickItem.transform);
            var hudObj = Instantiate(HudLand, UICanvas.transform);
            hudObj.GetComponent<HudLand>().BindObj = tower;
        }
    }

    // Update is called once per frame
	void Update ()
	{
	    CheckSelectLand();
        HandleInput();
    }

    private void HandleInput()
    {
        //if (GUIHelper.IsMouseOnGUI())
        //{
        //    UXLog.Debug("GUIHelper.IsMouseOnGUI()");
        //    return;
        //}

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("MouseDown");
            Vector3 realHitPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 9999, ~(1 << LayerMask.GetMask("land"))))
            {
                //  print(hit.transform.name)//打印选中物体的名字
           //     Debug.Log(hit.transform.position);
                realHitPos = hit.transform.position;

                iTween.MoveTo(mainCamera.gameObject, cameraPos + new Vector3(realHitPos.x - 3, 0, realHitPos.z + 3), 0.5f);
            }
        }

    }

    private void CheckSelectLand()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 9999, ~(1 << LayerMask.GetMask("land"))))
        {
        //    print(hit.transform.name);//打印选中物体的名字
            var landId = hit.transform.gameObject.GetComponent<LandInfo>().Id;
            if (landId != selectLandId)
            {
                selectLandId = landId;
                if (selectEff == null)
                {
                    selectEff = Instantiate(SelectEffType, hit.transform);
                }
                else
                {
                    selectEff.transform.SetParent(hit.transform);
                }
                selectEff.transform.localPosition = new Vector3(0, .6f, 0);

                UIWorldLandbar.Instance.SetLandId(landId);
            }
        }
    }
}
