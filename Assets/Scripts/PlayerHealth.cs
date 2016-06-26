using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float hpDelay;
    public float startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public Image healImage;
	
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashHurt = new Color(1f, 0f, 0f, 0.1f);
    public Color flashHeal = new Color(0f, 1f, 0f, 0.1f);
    public Color dead = new Color(0f, 0f, 0f, 1f);

    public Image died;
    private float trueHealth;
   
    bool isdead;
    bool damaged;
	bool healed;
    void Awake()
    {
        currentHealth = startingHealth;
		trueHealth = startingHealth;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
			damageImage.color = flashHurt;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

		if (healed)
		{
			healImage.color = flashHeal;
		}
		else
		{
			healImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		healed = false;



		currentHealth = Mathf.Lerp(currentHealth, trueHealth, hpDelay * Time.deltaTime);
        healthSlider.value = currentHealth;

        if (isdead)
        {
            died.color = Color.Lerp(Color.clear, Color.black, 100 * Time.deltaTime);
        }

	}

	void OnCollisionEnter(Collision coll)
	{
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "EnemyBullet")
		{
			TakeDamage(10);
		}
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        trueHealth -= amount;
	
        if(currentHealth <= 0 && !isdead)
        {
            Death();
        }
    }

	public void Heal(int amount)
	{
		healed = true;
		trueHealth += amount;
		
		if(trueHealth > 100)
		{
			trueHealth = 100;
			healed = false;
		}
	}

    void Death()
    {
        isdead = true;
        Invoke("loadstart", 5f);
    }
    void loadstart()
    {
        Application.LoadLevel(0);
    }
}
