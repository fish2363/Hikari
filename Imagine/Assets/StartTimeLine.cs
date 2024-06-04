using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimeLine : MonoBehaviour
{
    GameObject startCamera;
    GameObject playerCam;
    SpriteRenderer panel;
    float time = 0f;
    float F_time = 1f;
    public AudioSource lavaBGM;

    private void Awake()
    {
        playerCam = GameObject.Find("PlayerCam");
        startCamera = GameObject.Find("StartCamera");
        panel = GameObject.Find("Black").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        playerCam.SetActive(false);
        StartCoroutine(StartCamera());
    }

    IEnumerator StartCamera()
    {
        yield return new WaitForSecondsRealtime(3);

        Color alpha = panel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        yield return null;
        time = 0f;

        playerCam.SetActive(true);
        startCamera.SetActive(false);
        GameObject.Find("Player").GetComponent<StagePlayer>().enabled = true;
        lavaBGM.Play();

    }
}
