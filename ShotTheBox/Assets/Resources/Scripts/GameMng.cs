using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public static GameMng instance = null;

    //현재 스테이지와, 클리어 한 스테이지, PlayerPrefs를 통해 클리어 한 스테이지 값 저장
    public int now_stage = 1;
    public int clear_stage = 0;
    
    //게임 시작했는지, 끝났는지 판별
    public bool isStrat = false;
    public int BallCount = 0;
    
    //소리 크기
    public float VolumeEff = 0.5f;
    public AudioSource audio;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        clear_stage = PlayerPrefs.GetInt("Clear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
