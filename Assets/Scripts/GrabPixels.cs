using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GrabPixels : MonoBehaviour {

	public float MoveToCollector = 5f;
	public GameObject grabber;
	public GameObject collector;
	public GameObject player;
	public PlayerHealth playerHealth;                  

	public PlayerXp playerXp;
	

	bool getCollected = false;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		playerXp = player.GetComponent <PlayerXp> ();

		grabber = GameObject.Find("Grabber");
		collector = GameObject.Find("Collector");


	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (getCollected) {
			transform.position = Vector3.Lerp(transform.position, collector.transform.position, MoveToCollector * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == grabber)
		{
			Debug.Log ("pixel in range");
			// ... the player is in range.
			getCollected = true;
		}

		if(other.gameObject == collector)
		{
			Debug.Log ("pixel is collected");
			// ... the player is in range.
			playerHealth.Heal(1);
			Destroy (gameObject);
			playerXp.getXp(1);
		}
	}

}
