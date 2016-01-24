using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
	// Use this for initialization
	int max;
	int min;
	int guess;

	int maxGuesses = 5;

	public Text guessText;

	void Start ()
	{
		StartGame ();
	}
	
	public void GuessHigher ()
	{
		min = guess;
		NextGuess ();
	}

	public void GuessLower ()
	{
		max = guess;
		NextGuess ();
	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		NextGuess ();
	}
	
	void NextGuess ()
	{
		if (maxGuesses <= 0) {
			Application.LoadLevel ("Win");
		}

		guess = Random.Range (min, max + 1);
		guessText.text = guess.ToString ();
		maxGuesses--;
	}
}
