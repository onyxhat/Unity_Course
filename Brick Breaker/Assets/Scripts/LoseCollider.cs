using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Debug.Log ("Trigger: " + GetInstanceID ());
		levelManager.LoadLevel ("Lose");
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Debug.Log ("Collision: " + GetInstanceID ());
	}
}
