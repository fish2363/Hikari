using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Image panel;
    float time = 0f;
    float F_time = 1f;
    public GameObject main;
    [SerializeField] private GameObject roadingMan;

    public void StartgGame()
    {
        StartCoroutine(StartFade());
        print("≈¨∏Ø");
        panel.gameObject.SetActive(true);
        // ø¨»£ ∆©≈‰ æ¿ ∑ŒµÂ
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator StartFade()
    {
        Color alpha = panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        yield return null;
        time = 0f;
        main.gameObject.SetActive(false);
        roadingMan.GetComponent<SpriteRenderer>().DOFade(1, 2);
        yield return new WaitForSecondsRealtime(5);


        SceneManager.LoadScene(1);

    }
}
