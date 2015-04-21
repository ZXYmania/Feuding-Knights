using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	static protected GameMap m_GameMap;
	static protected Player[] m_players;
	static protected GameObject m_Characters;
	static protected Player currPlayer;
	static protected Mode[] m_modes;
	static protected Mode currMode;
	static protected GameObject m_interface;
	static protected CharacterController m_characterController;
	

	void Start ()
	{

		m_GameMap = gameObject.AddComponent<GameMap>();
		m_GameMap.Initialise();
		m_players = new Player[2];
		m_players[0] = gameObject.AddComponent<Player> ();
		m_players[0].GetCharacter().Initialise(m_GameMap.GetTile(5,6)); //Players spawn with a capital
		m_players[0].GetCharacter().AddTile(m_GameMap.GetTile(5,7));
		m_players[0].GetCharacter().AddTile(m_GameMap.GetTile(5,8));
		m_players[0].GetCharacter().AddTile(m_GameMap.GetTile(6,7));
		m_players[0].GetCharacter().AddTile(m_GameMap.GetTile(6,8));
		m_players[0].GetCharacter().GetTile(0).Build(Structure.Castle);
		m_characterController.AddCharacter(m_players[0].GetCharacter());
		currPlayer = m_players[0];
		m_modes = new Mode[3];
		m_modes [0] = gameObject.AddComponent<PlayerMode>() as Mode;
		m_modes[1] = gameObject.AddComponent<BuildMode>() as Mode;
		m_modes [2] = gameObject.AddComponent<ArmyMode> () as Mode;
		currMode = m_modes[1];
		currMode.OnModeEnter();
		//Debug.Log("Castle "+(int)Structure.Castle +", Barracks " +(int)Structure.Barracks+", walls "+(int)Structure.Wall);
	}



	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0)) 
		{
			currMode.OnClick ();
		} 
		else
		{
			currMode.OnHover();
		}
	}


	public GameObject FindObjectUnderCursor()
	{
		Ray mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (mousePoint, out hit, 1000000, currMode.GetLayerMask ()))
		{
			return hit.transform.gameObject;
		} else 
		{
			return null;
		}
	}	

	public void ChangeMode(int nextMode)
	{
		currMode.OnModeExit();
		currMode = m_modes[nextMode];
		currMode.OnModeEnter();
	}

	public void OnGUI()
	{
		if(GUI.Button(new Rect(10, 10, 150, 100),"Army"))
		{
			ChangeMode(2);
		}
	}

}


