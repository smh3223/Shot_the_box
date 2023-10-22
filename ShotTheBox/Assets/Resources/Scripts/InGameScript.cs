using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameScript : MonoBehaviour
{
    //레이캐스트 변수
    Ray PickRay;
    RaycastHit PickRHit;
    public Camera MainCam;

    //박스 생성 관련
    GameObject current_box = null;
    int current_num;

    //박스 카운트
    int[] BoxCount = new int[5];
    public Text[] CountText = new Text[5];

    //맵 세팅
    int[,] map = new int[10, 10];
    public GameObject[] Stages = new GameObject[10];
    GameObject stage;

    //현재 발사된 총알이 있는지
    public GameObject Bullets;

    //터치 못하게 막는 패널
    public GameObject DontTouchPanel;


    void Start()
    {
        //각 스테이지별 박스 갯수 읽어오기
        for (int i = 0; i < 5; i++)
        {
            BoxCount[i] = 5;
            CountText[i].text = BoxCount[i].ToString();
        }

        //스테이지 불러온 후, 맵 초기화
        stage = Instantiate(Stages[GameMng.instance.now_stage - 1]);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = 0;
            }
        }

        //스테이지 불러 오고, 그 스테이지 자식들을 다 읽어서 스테이지에 있는 오브젝트 좌표값 부분을 1로 채움
        Transform[] chts = stage.GetComponentsInChildren<Transform>();
        for (int i = 1; i < chts.Length; i++)
        {
            map[(int)chts[i].transform.position.x, (int)chts[i].transform.position.z] = 1;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameMng.instance.isStrat == false) // 시작 안했으면
        {
            BlockSettingUpdate(); // 블록 배치 가능
        }
        else // 시작 했으면
        {
            if(GameMng.instance.BallCount > 20) // 총알이 20개가 넘어가면 무한루프에 걸린것으로 판별
            {
                //리셋버튼 기능과 동일
                Transform[] chts = Bullets.GetComponentsInChildren<Transform>();
                for (int i = 1; i < chts.Length; i++)
                {
                    Destroy(chts[i].gameObject);
                }
                GameMng.instance.BallCount = 0;

                FinishCheck();

            }

            FinishCheck(); // 총알이 0개면 클리어 못한 판정
        }


        

    }

    //블럭 배치
    void BlockSettingUpdate()
    {
        if (Input.GetMouseButtonDown(0) && current_box == null)       // 마우스 눌렀고 / 지금 들고있는 박스가 없으면
        {
            PickRay = MainCam.ScreenPointToRay(Input.mousePosition);    // 카메라에서 마우스 포지션이 향하는 곳으로 레이를 쏨

            if (Physics.Raycast(PickRay, out PickRHit, 1000f))      // 레이를 쏴서 맞는 오브젝트를 PickRHit로 가져옴
            {
                if (PickRHit.transform.gameObject.tag == "InsBox")       // 생성 박스라면, 각 박스에 맞게 생성
                {
                    current_num = -1;
                    current_box = Instantiate(PickRHit.transform.gameObject);
                    if (PickRHit.transform.name == "LR_Box" && BoxCount[0] > 0)
                    {
                        current_num = 0;
                    }
                    else if (PickRHit.transform.name == "UD_Box" && BoxCount[1] > 0)
                    {
                        current_num = 1;
                    }
                    else if (PickRHit.transform.name == "LURD_Box" && BoxCount[2] > 0)
                    {
                        current_num = 2;
                    }
                    else if (PickRHit.transform.name == "LDRU_Box" && BoxCount[3] > 0)
                    {
                        current_num = 3;
                    }
                    else if (PickRHit.transform.name == "LRUD_Box" && BoxCount[4] > 0)
                    {
                        current_num = 4;
                    }

                    if (current_num != -1) 
                    {
                        BoxCount[current_num]--;
                        CountText[current_num].text = BoxCount[current_num].ToString();
                    }
                }

                if (PickRHit.transform.gameObject.tag == "Box") // 그냥 박스일 때는 생성 X, 움직여지게만
                {
                    current_box = PickRHit.transform.gameObject;
                    int x, z;
                    x = (int)current_box.transform.position.x;
                    z = (int)current_box.transform.position.z;
                    map[x, z] = 0;

                    switch (current_box.name)
                    {
                        case "LR_Box(Clone)":
                            current_num = 0;
                            break;
                        case "UD_Box(Clone)":
                            current_num = 1;
                            break;
                        case "LURD_Box(Clone)":
                            current_num = 2;
                            break;
                        case "LDRU_Box(Clone)":
                            current_num = 3;
                            break;
                        case "LRUD_Box(Clone)":
                            current_num = 4;
                            break;
                    }


                }
            }
        }

        if (Input.GetMouseButton(0) && current_box != null) // 마우스에 따라 박스가 움직이게
        {
            PickRay = MainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(PickRay, out PickRHit, 1000f))
            {
                current_box.transform.position = new Vector3(PickRHit.point.x, 0.5f, PickRHit.point.z);
            }
        }

        if (Input.GetMouseButtonUp(0) && current_box != null) // 마우스를 뗐을 때
        {
            current_box.tag = "Box";
            Vector3 pos = current_box.transform.position;

            int x = (int)(pos.x + 0.5f);
            int z = (int)(pos.z + 0.5f);


            if (x >= 0 && x <= 9 && z >= 0 && z <= 9)  // 보드 위에 내려놨는지
            {
                if (((x % 2 == 0 && z % 2 == 1) || (x % 2 == 1 && z % 2 == 0)) && map[x, z] == 0) // 검정색 칸 근처에 내려놨는지
                {
                    current_box.transform.position = new Vector3(x, 0.5f, z);
                    map[x, z] = 1;

                }
                else // 하얀색 칸이면 제거하고, 카운트 복구시킴
                {
                    Destroy(current_box);
                    BoxCount[current_num]++;
                    CountText[current_num].text = BoxCount[current_num].ToString();
                }
            }
            else  // 보드 위가 아니면 다 제거하고, 카운트도 복구시킴
            {
                Destroy(current_box);
                BoxCount[current_num]++;
                CountText[current_num].text = BoxCount[current_num].ToString();
            }

            current_box = null;
        }
    }


    public void FinishCheck()
    {
        //if(GameMng.instance.isStrat && Bullets.transform.childCount == 0) -> 총알이 생성되고, Balls에 등록되기 전에 이 함수가 호출되서 끝나는 판정이 일어남
        if(GameMng.instance.isStrat && GameMng.instance.BallCount == 0)
        {
            DontTouchPanel.SetActive(false);
            GameMng.instance.isStrat = false;

            Destroy(stage);
            stage = Instantiate(Stages[GameMng.instance.now_stage - 1]);

        }
    }

    


}
