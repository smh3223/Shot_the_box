using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBox : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Bullet") // 마지막 박스에 총알이 닿으면 클리어
        {
            if (GameMng.instance.now_stage == GameMng.instance.clear_stage + 1) // 현재 스테이지와, 클리어 해야 하는 스테이지라면
            {
                GameMng.instance.clear_stage++; // 클리어 스테이지 증가

                PlayerPrefs.SetInt("Clear", GameMng.instance.clear_stage); // 클리어 스테이지 PlayerPrefs를 통해 저장
            }
            GameMng.instance.now_stage++; // 현재 스테이지 증가
            
            // GameMng 초기화 --> Load 해도 매니저 값은 안 바뀌기 때문
            GameMng.instance.isStrat = false;
            GameMng.instance.BallCount = 0;

            SceneManager.LoadScene("GameScene"); // 씬 다시 불러오기
        }
    }

}
