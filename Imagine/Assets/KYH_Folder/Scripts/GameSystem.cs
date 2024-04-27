using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSystem : MonoBehaviour
{
    [SerializeField] public static int playerType = 2; //�÷��̾� ���
    GameObject BabySprite;
    GameObject KidSprite;


    private void Awake()
    {
        KidSprite =GameObject.Find("kidSprite");
        BabySprite =GameObject.Find("BabySprite");
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerType)
        {
            case 1:
                BabySprite.SetActive(true);
                KidSprite.SetActive(false);
                break;
            case 2:
                BabySprite.SetActive(false);
                KidSprite.SetActive(true);
                break;
        }
    }
}
