using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public float startTime;
    public bool destroyed = false;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (!destroyed && Time.time - startTime > 3.0f)
        //{
        //    destroyed = true;
        //    Destroy(gameObject);
        //}

    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        Destroy(gameObject);

       
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
