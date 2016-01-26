using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start ()
	{
		paddleToBallVector = this.transform.position - paddle.transform.position;
		Debug.Log ("P2B Vector: " + paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			//Lock ball relative to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//Wait for click to launch ball
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Ball Release");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (0f, 10f);
			}
		}
	}
}
