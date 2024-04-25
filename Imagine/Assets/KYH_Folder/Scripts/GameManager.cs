using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public TalkManagement talkManagement;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int stopAni = 1;
    Transform kid;
    Transform friend;
    public int talkIndex;
    bool player;
    CinemachineVirtualCamera camera;

    public void Awake()
    {
        camera = GameObject.Find("MainPlayCam").GetComponent<CinemachineVirtualCamera>();
        kid = GameObject.Find("Player").GetComponent<Transform>();
        friend = GameObject.Find("Friend").GetComponent<Transform>();
    }

    private void Update()
    {
        if(!player)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                stopAni = 2;
                player = true;
                camera.Follow = friend;
            }
        }
        else if (Input.GetButtonDown("Fire1") && player == true)
        {
            stopAni = 1;
            player = false;
            camera.Follow = kid;
        }
    }

    //public void Action(GameObject scanObj)
    //{
    //    if(isAction)
    //    {
    //        isAction = false;
    //    }
    //    else
    //    {
    //        isAction = true;
    //        scanObject = scanObj;
    //        ObjData objData = scanObject.GetComponent<ObjData>();
    //        //Talk(objData.id, objData.isNpc);
    //    }
    //    talkPanel.SetActive(isAction);
    //}

    //void Talk(int id, bool isNpc)
    //{
    //    string talkData = talkManagement.GetTalk(id, talkIndex);

    //    if(isNpc)
    //    {
    //        talkText.text = talkData;
    //    }
    //    else
    //    {
    //        talkText.text = talkData;
    //    }
    //}
}
