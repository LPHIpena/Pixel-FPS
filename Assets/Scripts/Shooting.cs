using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject bullet_prefab;
    public AudioClip laserShot;
    public GameObject gunshot;
    public GameObject gunlvl2;
    public GameObject gunlvl21;
    public GameObject gunlvl3;
 
    private int lvl = 1;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        gunlvl2.SetActive(false);
        gunlvl21.SetActive(false);
        gunlvl3.SetActive(false);


    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject gunShot = Instantiate(gunshot, this.transform.position, transform.rotation) as GameObject;


            //Vector3 force;
            GameObject spawnpoint = GameObject.Find("BulletSpawnPoint");
            GameObject bullet = Instantiate(bullet_prefab,
                                spawnpoint.transform.position,
                                spawnpoint.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
            Destroy(bullet.gameObject, 3f);

            if (lvl == 2)
            {
                spawnpoint = GameObject.Find("BulletSpawnPointlvl2");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);

                spawnpoint = GameObject.Find("BulletSpawnPointlvl21");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);
            }
            if(lvl == 3)
            {
                spawnpoint = GameObject.Find("BulletSpawnPointlvl2");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);

                spawnpoint = GameObject.Find("BulletSpawnPointlvl21");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);

                spawnpoint = GameObject.Find("BulletSpawnPointlvl3");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);

                spawnpoint = GameObject.Find("BulletSpawnPointlvl31");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);
                spawnpoint = GameObject.Find("BulletSpawnPointlvl32");
                bullet = Instantiate(bullet_prefab,
                                    spawnpoint.transform.position,
                                    spawnpoint.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
                Destroy(bullet.gameObject, 3f);

            }
        }
	}
    public void lvlup()
    {
        lvl++;
        if(lvl == 2)
        {
            gunlvl2.SetActive(true);
            gunlvl21.SetActive(true);
        }
        if (lvl == 3)
        {
            gunlvl3.SetActive(true);
        }
    }
}
