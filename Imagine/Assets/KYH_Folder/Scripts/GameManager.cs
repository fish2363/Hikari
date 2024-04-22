using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManagement talkManagement;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    [SerializeField] public bool isAction;
    public int talkIndex;

    //¥Î»≠
    public void Action(GameObject scanObj)
    {
        if(isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        }
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManagement.GetTalk(id, talkIndex);

        if(isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
    }
}
