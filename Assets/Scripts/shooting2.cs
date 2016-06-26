using UnityEngine;
using System.Collections;

public class shooting2 : MonoBehaviour {

    public GameObject bullet_prefab;
    public AudioClip laserShot;
    public GameObject gunshot;



    private AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            GameObject gunShot = Instantiate(gunshot, this.transform.position, transform.rotation) as GameObject;


            //Vector3 force;
            GameObject spawnpoint = GameObject.Find("BulletSpawnPoint2");
            GameObject bullet = Instantiate(bullet_prefab,
                                spawnpoint.transform.position,
                                spawnpoint.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
            Destroy(bullet.gameObject, 3f);
        }
    }
}
