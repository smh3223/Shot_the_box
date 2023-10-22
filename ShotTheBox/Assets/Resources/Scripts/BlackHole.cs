using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    GameObject WhiteHole;

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
        //화이트홀을 찾아서 화이트홀 위치로 이동

        WhiteHole = GameObject.Find("WhiteHole");

        other.transform.position = WhiteHole.transform.position;
    }


}
