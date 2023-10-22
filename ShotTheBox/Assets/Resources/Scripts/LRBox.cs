using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRBox : MonoBehaviour
{
    public GameObject bullet;
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
        if(other.transform.tag == "Bullet")
        {
            audio.Play();

            GameMng.instance.BallCount += 2;

            GameObject LeftBullet = Instantiate(bullet);
            GameObject RightBullet = Instantiate(bullet);

            LeftBullet.transform.position = new Vector3(transform.position.x - 1, 0.5f, transform.position.z);
            LeftBullet.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

            RightBullet.transform.position = new Vector3(transform.position.x + 1, 0.5f, transform.position.z);
            RightBullet.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
