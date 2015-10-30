using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		if (myState == States.cell) {
			state_cell();
		} else if (myState == States.mirror) {
			state_mirror();
		} else if (myState == States.sheets_0) {
			state_sheets_0();
		} else if (myState == States.lock_0) {
			state_lock_0();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror();
		} else if (myState == States.sheets_1) {
			state_sheets_1();
		} else if (myState == States.lock_1) {
			state_lock_1();
		} else if (myState == States.freedom) {
			state_freedom();
		};
	}
	
	void state_cell () {
		text.text = @"
			You awake in a prison cell, and you want to escape.
			There are some dirty sheets on the bed, mirror on the wall and the
			door is locked from the outside.
			
			[Inspect (S)heets / (M)irror / (L)ock]";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		};
	}
	
	void state_mirror () {
		text.text = @"
			The mirror is broken and crusted with
			
			[(R)eturn to checking your cell]
			";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		};
	}
	
	void state_sheets_0 () {
		text.text = @"
			The bedding is disgusting; you can't believe you sleep here.
			There doesn't appear to be anything of use.
			
			[(R)eturn to checking your cell]
			";
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		};
	}
	
	void state_lock_0 () {}
	
	void state_cell_mirror () {}
	
	void state_sheets_1 () {}
	
	void state_lock_1 () {}
	
	void state_freedom () {}
}//States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom}
