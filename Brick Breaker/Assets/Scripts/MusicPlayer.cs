using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	// Awake() is called before Start()
	void Awake ()
	{
		Debug.Log ("MusicPlayer Awake: " + GetInstanceID ());

		if (instance != null) {
			Debug.Log ("Destroying Duplicate MusicPlayer Instance: " + GetInstanceID ());
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
