using UnityEngine;
using System.Collections;

public class waHit : MonoBehaviour {

	public GameObject bodyPart;

	private bool wasHit = false;

	public void OnCollisionEnter(Collision hitter)
	{
		GameObject collidedWith = hitter.gameObject;
		if(collidedWith.tag == "Bullet"){
			this.wasHit = true;
		}
	}

	public bool Hit(){
		return this.wasHit;
	}

	public void resetHit(){
		wasHit = false;
	}

	void Update(){
		//Debug.Log (gameObject.name);
	}
}
