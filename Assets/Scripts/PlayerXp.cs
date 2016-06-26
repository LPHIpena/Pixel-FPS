using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerXp : MonoBehaviour {
	

	public float startingXp = 0;
	public float currentXp;
	public Slider xpSlider;

    public int lvl = 1;
    GameObject player;
    Shooting shootref;
    bool lvlup = true;


	void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        shootref = player.GetComponent<Shooting>();
        currentXp = startingXp;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
        if(lvl < 3 && currentXp >= xpSlider.maxValue && lvlup)
        {
            lvlup = false;
            xpSlider.value = 0;
            currentXp = 0;
            xpSlider.maxValue *= 2;
            shootref.lvlup();

            lvl++;
            Invoke("unsetlevel", 2f);
        }
	}
	

	public void getXp(int amount)
	{
		currentXp += amount;
		xpSlider.value = currentXp;
	}
	
    void unsetlevel()
    {
        lvlup = true;
    }

}
