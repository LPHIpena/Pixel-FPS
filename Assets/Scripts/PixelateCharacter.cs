using UnityEngine;
using System.Collections;

public class PixelateCharacter : MonoBehaviour
{
	//public Collider head;
	//public Collider body;
	//public Collider Lleg;
	//public Collider Rleg;
	

    public Renderer rend;
    public GameObject pixelPrefab;

    PlayerHealth playerHealth;
    public float size;
    private bool destroyedHead = false;
    private bool destroyedRarm = false;
    private bool destroyedLArm = false;
    private bool destroyedRLeg = false;
    private bool destroyedLLeg = false;

    private string name;
    // Use this for initialization
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        playerHealth = GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyedHead)
        {
            destroyedHead = false;
            Invoke("ReformHead", 2f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Bullet")
        {
			Debug.Log ("hit");
            playerHealth.TakeDamage(5);
			//bool headhit = head.gameObject.Hit();
            //collider.tag == "Head";
			Collider temp = gameObject.GetComponent<Collider>();
			Debug.Log (gameObject.name);
			Debug.Log(collidedWith.GetInstanceID());
            Pixel();
        }
    }


    void Pixel()
    {
        destroyedHead = true;

        int numberOfPixels = (int)(size / .1) + 8;
        if (numberOfPixels > 50) { numberOfPixels = 50; }

        for (int i = 0; i < numberOfPixels; i++)
        {
            GameObject pixel = Instantiate(pixelPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
            pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;

        }
    }

    void ReformHead()
    {

    }
    
}
