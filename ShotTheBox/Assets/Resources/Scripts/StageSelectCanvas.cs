using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectCanvas : MonoBehaviour
{
    public Text clearStageText;
    public Text stageText;

    public AudioSource audio;

    void Start()
    {
        clearStageText.text = "이동할 스테이지 선택 (1 ~ " + (GameMng.instance.clear_stage+1) + ")";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //선택한 스테이지로 이동
    public void StartBtn()
    {
        audio.Play();
        int stage = int.Parse(stageText.text);

        if (stage <= GameMng.instance.clear_stage + 1)
        {
            GameMng.instance.now_stage = stage;
            SceneManager.LoadScene("GameScene");
        }
    }

}
