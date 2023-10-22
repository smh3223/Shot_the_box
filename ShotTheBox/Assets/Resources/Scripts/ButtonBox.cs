using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    public GameObject Walls;
    public int num;
    public AudioSource audio;
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
        //ButtonWalls를 찾아서 제거

        Walls = GameObject.Find("ButtonWalls" + num);

        Destroy(Walls);
        Destroy(gameObject);
    }

}
