using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Character m_character;
	public Character GetCharacter(){return m_character;}


	public void Initialise(Tile[] givenTile,string givenName)
	{
		m_character = gameObject.AddComponent<Character> ();
		m_character.Initialise(givenTile);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	//Actions

	//public void Diplomacy()		//Declare War/Peace Deal/Manage Underlings/Embargo/Trade Agreement
	//public void Espionage()		//Update Ledger/Incite Rebellion
	//public void
}
