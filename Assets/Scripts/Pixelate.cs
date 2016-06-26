using UnityEngine;
using System.Collections;

public class Pixelate : MonoBehaviour {

    public Collider collide;
    public Renderer rend;
    public GameObject pixelPrefab;

    public GameObject explosion;


    public float size;
    private bool destroyed = false;

	// Use this for initialization
	void Start () {
        size = transform.localScale.x * transform.localScale.z * transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (destroyed)
        {
            destroyed = false;
            Invoke("Reform", 2f);
        }
	}

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Bullet")
        {
			Debug.Log(gameObject.name);
            Pixel();
            GameObject explode = Instantiate(explosion, this.transform.position, transform.rotation) as GameObject;

        }
    }

    void Pixel()
    {


        destroyed = true;
        collide.enabled = false;
        rend.enabled = false;

        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;

        float scale = transform.localScale.x;

        //CENTER POINTS////////////////////////
        GameObject pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos, zPos + scale/2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos + scale / 2.0f, zPos), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos - scale / 2.0f, zPos), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos, zPos), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos, zPos), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);
        //CENTER POINTS////////////////////////

        //CORNERS//////////////////////////TOP
        pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos + scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos + scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos + scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos + scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        //CORNERS//////////////////////////BOTTOM
        pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos - scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos - scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos - scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);

        pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos - scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
        pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 2);
        //CORNERS//////////////////////////

    }

    void Reform()
    {
        collide.enabled = true;
        rend.enabled = true;
    }
}
