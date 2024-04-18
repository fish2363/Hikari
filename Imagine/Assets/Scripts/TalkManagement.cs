using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManagement : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(101, new string[] { "�׷���! �������� ����.." });
        talkData.Add(1, new string[] { "����� �׽�Ʈ�� ���̳�?" });
        talkData.Add(2, new string[] { "����� �׽�Ʈ�� ���̴�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
