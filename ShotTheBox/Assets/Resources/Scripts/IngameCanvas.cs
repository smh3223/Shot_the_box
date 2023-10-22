using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCanvas : MonoBehaviour
{
    public GameObject bullet;
    public GameObject DontTouchPanel;

    public GameObject Bullets;

    public GameObject RuleObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //시작 버튼
    public void StartBtn()
    {
        //StartPos를 찾아서 출발
        GameObject temp = GameObject.Find("StartPos");
        Vector3 pos = temp.transform.position;
        Instantiate(bullet).transform.position = pos;

        GameMng.instance.BallCount++;
        GameMng.instance.isStrat = true;

        DontTouchPanel.SetActive(true); // DontTouchPanel 활성화
    }

    //초기화 버튼
    public void ResetBtn()
    {
        Transform[] chts = Bullets.GetComponentsInChildren<Transform>();
        for (int i = 1; i < chts.Length; i++)
        {
            Destroy(chts[i].gameObject); // 공을 모두 없애주기
        }
        GameMng.instance.BallCount = 0;

        //FinishCheck() 호출
        RuleObject.GetComponent<InGameScript>().FinishCheck();
    }



}
