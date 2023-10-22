using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fspeed = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        //생성되면 Balls 밑에 등록되고, 5초 후 제거되게 만들어줌

        GameObject par = GameObject.Find("Balls");
        transform.parent = par.transform;
        Invoke("DestroyBullet", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(0f, 0f, 1f);
        transform.Translate(vec * Time.deltaTime * fspeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 박스나 벽에 충돌하면 제거
        if (other.transform.tag == "Box" || other.transform.tag == "Wall")
        {
            DestroyBullet();   
        }
    }
    
    // GameMng 에서 BallCount를 줄여주고, 제거
    private void DestroyBullet()
    {
        GameMng.instance.BallCount--;
        Destroy(gameObject);
    }

}
