using System;
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
    private Camera mainCamera;

    // Use this for initialization
    void Start ()
    {
        GenerateLandscape();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
        HandleInput();
    }


    private bool pressing = false;
    private bool dragging = false;
    private float touchDownTime = 0f;
    private Vector3 touchPosition;

    private void HandleInput()
    {
        //if (GUIHelper.IsMouseOnGUI())
        //{
        //    UXLog.Debug("GUIHelper.IsMouseOnGUI()");
        //    return;
        //}

        //if (GUIManager.Instance.IsModal)
        //{
        //    return;
        //}

        if (Input.GetMouseButtonUp(0))
        {
            // Debug.Log(pressing + " " + (Time.time - touchDownTime));
            if (pressing && (Time.time - touchDownTime) < 0.3f)
            {
              //  HandleClick();
            }

            pressing = false;
            dragging = false;

            return;
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("MouseDown");
            Vector3 realHitPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //  print(hit.transform.name)//打印选中物体的名字
                Debug.Log(hit.transform.position);
                realHitPos = hit.transform.position;
            }
            else
            {
                return;
            }

            if (!pressing)
            {
                //Debug.Log("MouseDown Begin Press");
                touchDownTime = Time.time;
                touchPosition = realHitPos;
                pressing = true;

                return;
            }

            if (!dragging && Vector3.Distance(touchPosition, realHitPos) > 1)
            {
                //Debug.Log("MouseDown Begin Drag");
                dragging = true;
                touchPosition = realHitPos;

                return;
            }

            if (dragging)
            {
                var posOffset = (touchPosition - realHitPos);
                var offset = new Vector3(posOffset.x, 0, posOffset.z);

                Debug.Log(string.Format("MouseDown Dragging {0}", offset));
                mainCamera.transform.position += offset;
            //    mainCamera.transform.LookAt(realHitPos);

               // mainCamera.transform.position = GUIHelper.CheckLimit(mainCamera.transform.position, 20, 104, -21, 60);//限制屏幕区域
               dragging = false;
                // MainCamera.transform.Translate(offset* 0.01f);
            }
        }

        ////Zoom out
        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    if (mainCamera.fieldOfView < 80)
        //        mainCamera.fieldOfView += 10;

        //    if (mainCamera.orthographicSize <= 20)
        //        mainCamera.orthographicSize += 0.5F;
        //}

        ////Zoom in
        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    if (mainCamera.fieldOfView > 40)
        //        mainCamera.fieldOfView = Math.Max(20, mainCamera.fieldOfView - 10);

        //    if (mainCamera.orthographicSize >= 1)
        //        mainCamera.orthographicSize -= 0.5F;
        //}

    }
}
