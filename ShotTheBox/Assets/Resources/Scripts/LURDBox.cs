using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LURDBox : MonoBehaviour
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

            GameObject LUBullet = Instantiate(bullet);
            GameObject RDBullet = Instantiate(bullet);

            LUBullet.transform.position = new Vector3(transform.position.x - 1f, 0.5f, transform.position.z + 1f);
            LUBullet.transform.rotation = Quaternion.Euler(0f, -45f, 0f);

            RDBullet.transform.position = new Vector3(transform.position.x + 1f, 0.5f, transform.position.z - 1f);
            RDBullet.transform.rotation = Quaternion.Euler(0f, 135f, 0f);
        }
    }
}
