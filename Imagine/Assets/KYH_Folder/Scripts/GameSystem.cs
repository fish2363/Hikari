using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static int playerType = 2; //플레이어 모습
    GameObject BabySprite;
    GameObject KidSprite;

    private void Awake()
    {
        KidSprite =GameObject.Find("kidSprite");
        BabySprite =GameObject.Find("BabySprite");
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
