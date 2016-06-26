using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyPrefab;
    public GameObject spawnpoints;
	public float spawnRate;
	public float hp;
	public float attackRate;
    public float startEnemies;
    public float numEnemies;
	public float curEnemies;
    public int Enemies;
    public int MaxEnemies;

    bool endofRound = false;
    int round = 1;

	Vector3[] SpawnLocations;

	// Use this for initialization
	void Start () {
        numEnemies = startEnemies;
        curEnemies = numEnemies;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < spawnRate) {
			if(Enemies < MaxEnemies && curEnemies > 0){
				GameObject enemy = Instantiate(enemyPrefab, spawnpoints.transform.GetChild(Random.Range(0,8)).position, Quaternion.identity) as GameObject;
				curEnemies--;
                Enemies++;
            }
		}

        if (numEnemies <= 0 && !endofRound)
        {
            endofRound = true;
            showscore();
            Invoke("startNextRound", 5f);
        }
	}

	public float getStartHealth(){
		return hp;
	}

	public float getAttackRate(){
		return attackRate;
	}
    public void killEnemy()
    {
        Enemies--;
        numEnemies--;
    }

    void showscore()
    {

    }
    void hidescore()
    {

    }
    void startNextRound(){
        ++round;
        startEnemies += 2;
        numEnemies = startEnemies;
        curEnemies = numEnemies;
        hp += 5f;
        attackRate -= .05f;

        if(attackRate < .3f)
        {
            attackRate = .3f;
        }
        endofRound = false;
	}
}
