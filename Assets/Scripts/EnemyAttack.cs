using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks;     // The time in seconds between each attack.

	
	Animator anim;                              // Reference to the animator component.
	public GameObject bullet_prefab;
	public GameObject gunshot;
	public GameObject player;                          // Reference to the player GameObject.
	public PlayerHealth playerHealth;                  // Reference to the player's health.
	public EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	public EnemyManager enemyStats;
	public bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.

	public NavMeshAgent enemy;
	
	void Awake ()
	{
		// Setting up the references.
		enemyStats = GameObject.Find("EnemyManager").GetComponent<EnemyManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		enemy = this.gameObject.GetComponent<NavMeshAgent> ();
		timeBetweenAttacks = enemyStats.getAttackRate ();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is in range.
			playerInRange = true;
			enemy.speed = 2;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			enemy.speed = 4;
			
			// ... the player is no longer in range.
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{

			// ... attack.
			Attack ();
		}
		
		// If the player has zero or less health...
		if(playerHealth.currentHealth <= 0)
		{
			// ... tell the animator the player is dead.
			
		}
	}
	
	
	void Attack ()
	{
		// Reset the timer.
		timer = 0f;
		
		GameObject gunShot = Instantiate(gunshot, this.transform.position, transform.rotation) as GameObject;
		
		
		//Vector3 force;
		Transform spawnpoint = gameObject.transform.GetChild(0);
		GameObject bullet = Instantiate(bullet_prefab,
		                                spawnpoint.transform.position,
		                                spawnpoint.transform.rotation) as GameObject;

		bullet.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * 2000);
		Destroy(bullet.gameObject, 3f);
	}
}