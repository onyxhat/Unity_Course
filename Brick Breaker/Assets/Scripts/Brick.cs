using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	private LevelManager levelmanager;

	public int maxHits;
	private int timesHit;

	// Use this for initialization
	void Start ()
	{
		//Filter load private resources
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();

		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Debug.Log ("Brick Hit: " + GetInstanceID ());
		timesHit++;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
		}
	}

	//TODO Remove this method when we can really WIN
	void SimulateWin ()
	{
		levelmanager.LoadNextLevel ();
	}
}
