using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;
	
	void Start () {
			StartGame ();
		}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess ();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess ();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I win!");
			StartGame ();
		};
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		guess = 500;
		
		print ("=========================");
		print ("Welcome to Number Wizard!");
		print ("Pick a Number, but don't tell me:");
		print ("Pick a number between " + min + " & " + max);
		print ("Is the number higher or lower than " + guess + "?");

		max++;
	}
	
	void NextGuess () {
		guess = (max + min) / 2;
		print ("Is the number higher or lower than " + guess + "?");
		print ("[Up/Down/Enter]:");
	}
}
