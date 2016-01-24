using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel (string name)
	{
		Debug.Log ("Load level: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest ()
	{
		Debug.Log ("Exiting Game.");
		Application.Quit ();
	}
}
