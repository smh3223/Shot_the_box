using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDBox : MonoBehaviour
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
        if (other.transform.tag == "Bullet")
        {
            audio.Play();
            GameMng.instance.BallCount += 2;

            GameObject UpBullet = Instantiate(bullet);
            GameObject DownBullet = Instantiate(bullet);

            UpBullet.transform.position = new Vector3(transform.position.x , 0.5f, transform.position.z + 1f);
            UpBullet.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            DownBullet.transform.position = new Vector3(transform.position.x , 0.5f, transform.position.z - 1f);
            DownBullet.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
