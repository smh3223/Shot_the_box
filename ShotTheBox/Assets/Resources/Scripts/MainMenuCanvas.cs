using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuCanvas : MonoBehaviour
{
    public AudioSource audio;
    public GameObject Option;

    public Slider BgSlider;
    public Slider EffSlider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameMng.instance.audio.volume = BgSlider.value;
        GameMng.instance.VolumeEff = EffSlider.value;
        audio.volume = EffSlider.value;
    }

    //시작 버튼 누르면 StageSelectScene 으로 이동
    public void StartBtn()
    {
        audio.Play();
        SceneManager.LoadScene("StageSelectScene");
    }

    //옵션창 활성화
    public void OptionBtn()
    {
        audio.Play();
        Option.SetActive(true);
    }

    //옵션창 비활성화
    public void OptionCloseBtn()
    {
        audio.Play();
        Option.SetActive(false);
    }

    // 나가기 버튼 누르면 프로그램 종료
    public void ExitBtn()
    {
        audio.Play();
        Application.Quit();
    }

}
