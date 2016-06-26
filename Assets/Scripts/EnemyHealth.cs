using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public GameObject pixelPrefab;

	public float flashSpeed = 5f;
    public float startingHealth = 100;            // The amount of health the enemy starts the game with.
    public float currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    //public AudioClip deathClip;                 // The sound to play when the enemy dies.


    Animator anim;                              // Reference to the animator.
    //AudioSource enemyAudio;                     // Reference to the audio source.
   // ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
	bool damaged = false;
	EnemyManager enemyStats;
	public Renderer[] children;

	public Material hitColor;
	public Material ColorParent;
	
	GameObject body;
	GameObject Rfoot;
	GameObject Lfoot;
	
	

    void Awake()
    {
       
        // Setting the current health when the enemy first spawns.
		enemyStats = GameObject.Find("EnemyManager").GetComponent<EnemyManager> ();
		startingHealth = enemyStats.getStartHealth ();
		currentHealth = startingHealth;
		ColorParent = gameObject.GetComponent<Renderer> ().material;
		children = gameObject.GetComponentsInChildren<Renderer>();
		
    }

    void Update()
    {
		if (damaged)
		{
			for(int i = 3; i < 7; i++){
				children[i].enabled = false;
			}
			Invoke ("makeVisible",.2f);
		}
		else
		{


		}
		damaged = false;
    }

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Bullet")
		{
			TakeDamage(10);
		}


	}


    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            return;

        currentHealth -= amount;
		damaged = true;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

	void makeVisible(){

		for (int i = 3; i < 7; i++) {
			children [i].enabled = true;
		}
	}

    void Death()
    {
        // The enemy is dead.
        isDead = true;
        enemyStats.killEnemy();
        // Turn the collider into a trigger so shots can pass through it.
		float xPos = transform.position.x;
		float yPos = transform.position.y;
		float zPos = transform.position.z;
		
		float scale = transform.localScale.x;


		//CENTER POINTS////////////////////////
		GameObject pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos, zPos + scale/2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos + scale / 2.0f, zPos), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos, yPos - scale / 2.0f, zPos), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos, zPos), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos, zPos), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		//CENTER POINTS////////////////////////
		
		//CORNERS//////////////////////////TOP
		pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos + scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos + scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos + scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos + scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		//CORNERS//////////////////////////BOTTOM
		pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos - scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos + scale / 2.0f, yPos - scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos - scale / 2.0f, zPos - scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		
		pixel = Instantiate(pixelPrefab, new Vector3(xPos - scale / 2.0f, yPos - scale / 2.0f, zPos + scale / 2.0f), Quaternion.identity) as GameObject;
		pixel.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
		pixel.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * 20);
		//CORNERS//////////////////////////
		Destroy (gameObject);
    }


 
}