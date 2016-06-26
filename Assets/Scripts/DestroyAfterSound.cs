using UnityEngine;
using System.Collections;

public class DestroyAfterSound : MonoBehaviour {

    private float totalTime;

	// Use this for initialization
	void Start () {
        AudioSource audio = this.GetComponent<AudioSource>();
        totalTime = audio.clip.length;
	}
	
	// Update is called once per frame
	void Update () {
        totalTime -= Time.deltaTime;
        if(totalTime <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
