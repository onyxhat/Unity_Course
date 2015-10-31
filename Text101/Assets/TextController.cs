using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public Text prompt;
	private enum States {hotel_room, desk, bed, bathroom, door, toilet, lobby, restaurant, exit, dead};
	private States myState;
	private bool hasKey;
	private string item;
	
	// Use this for initialization
	void Start () {
		myState = States.hotel_room;
		hasKey = false;
		item = null;
		prompt.color = UnityEngine.Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.bathroom)	{state_bathroom();}
		else if (myState == States.bed)			{state_bed();}
		else if (myState == States.hotel_room)	{state_hotel_room();}
		else if (myState == States.desk)		{state_desk();}
		else if (myState == States.door)		{state_door();}
		else if (myState == States.toilet)		{state_toilet();}
		else if (myState == States.lobby)		{state_lobby();}
		else if (myState == States.restaurant)	{state_restaurant();}
		else if (myState == States.exit)		{state_exit();}
		else if (myState == States.dead)		{state_dead();};
	}
	
	void state_hotel_room () {
		text.text = @"
			You awake in a hotel room in India. Your stomach aches with both
			the need to eat - and void whatever is or once was in it. Looking
			around you see a bed with dirty sheets, a desk, a door and
			a bathroom.";
			
		prompt.text = "[(B)ed / Des(K) / (D)oor / B(A)throom]";
		
		if 		(Input.GetKeyDown(KeyCode.B)) {myState = States.bed;}
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.door;}
		else if (Input.GetKeyDown(KeyCode.A)) {myState = States.bathroom;}
		else if (Input.GetKeyDown(KeyCode.K)) {myState = States.desk;};
	}
	
	void state_bed () {
		text.text = @"
			The bed is strewn with water bottles, sick, room service menus and feces.
			There doesn't seem to be anything of use here.";
			
		prompt.text = "[(R)eturn]";
		
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;};
	}
	
	void state_bathroom () {
		text.text = @"
			You enter the bathroom with a strange sense of deja` vu; you've
			done this many times before. You see a toilet and a hose, but
			inexplicably no toilet paper. Bad things have happened here.";
			
		prompt.text = "[(T)oilet / (R)eturn]";
		
		if 		(Input.GetKeyDown(KeyCode.T)) {myState = States.toilet;}
		else if (Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;};
	}
	
	void state_toilet () {
		text.text = @"
			'ARRRRRRGHHHHHHHHHHHHHHHHH!!!!'
			
			You feel better...";
		
		prompt.text = "[(B)athroom / (R)eturn]";
		
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.bathroom;};
	}
	
	void state_door () {
		if (hasKey) {
			text.text = @"
				You use the keycard to unlock the door. You hear a click
				and the handle now turns freely.";
				
			prompt.text = "[(E)xit / (R)eturn]";
				
			if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;}
			else if (Input.GetKeyDown (KeyCode.E)) {myState = States.lobby;};
		} else {
			text.text = @"
				You check the door, but it's locked. It doesn't look
				like you can do anything but (R)eturn to the hotel room.";
				
			prompt.text = "[(R)eturn]";
				
			if (Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;};
		};
	}
	
	void state_desk () {
		if (hasKey) {
			text.text = @"
				Looking over the desk - you find bottles of water.";
				
			prompt.text = "[(W)ater / (R)eturn]";
		} else {
			text.text = @"
				Looking over the desk - you find a plastic (K)eycard and
				(B)ottles of water. (R)eturn to the hotel room?";
				
			prompt.text = "[(W)ater / (K)eycard / (R)eturn]";
		};
		
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.hotel_room;}
		else if (Input.GetKeyDown(KeyCode.W)) {item = "water"; myState = States.dead;}
		else if (Input.GetKeyDown (KeyCode.K)) {hasKey = true;};
	}
	
	void state_dead () {
		text.text = string.Format(@"
			The {0} was contaminated; you've died of dysentary.", item);
			
		prompt.color = UnityEngine.Color.red;
		prompt.text = "[(T)ry again?]";
		
		if (Input.GetKeyDown(KeyCode.T)) {Start();};
	}
	
	void state_lobby () {
		text.text = @"
			The door opens to a long corridor. In the distance you hear the
			clinking of dishes and silverware. You wander out to the lobby
			and notice a restaurant and an exit.";
			
		prompt.text = "[(R)estaurant / (E)xit]";
		
		if 		(Input.GetKeyDown (KeyCode.R)) {myState = States.restaurant;}
		else if (Input.GetKeyDown (KeyCode.E)) {myState = States.exit;};
	}
	
	void state_restaurant () {
		text.text = @"
			You enter the restaurant and are met by beautiful sights and
			smells of a delicious looking buffet. The staff are eager to
			help you find a seat and fetch whatever you might want.";
			
		prompt.text = "[(E)at / (D)rink / (B)e Merry / (R)eturn]";
			
		if 		(Input.GetKeyDown (KeyCode.R)) {myState = States.lobby;}
		else if (Input.GetKeyDown (KeyCode.E)) {item = "food"; myState = States.dead;}
		else if (Input.GetKeyDown (KeyCode.D)) {item = "drink"; myState = States.dead;}
		else if (Input.GetKeyDown (KeyCode.B)) {item = "merriment"; myState = States.dead;};		
	}
	
	void state_exit () {
		text.text = @"
			You walk outside to warm beautiful weather. You decide to take a stroll to get some
			fresh air. No sooner do you set foot on the road than you get hit by a rickshaw
			(you really should have looked).
			
			Fortunately help is nearby - and the rickshaw driver offers to take you to the
			hospital. You survive your crash injuries, but ultimately succumb to dysentary...";
			
		prompt.color = UnityEngine.Color.red;
		prompt.text = "[Game Over]";
	}
}