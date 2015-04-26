using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	static protected GameMap m_GameMap;
	static protected Player[] m_players;
	static protected GameObject m_Characters;
	static protected int currPlayer;
	static protected Mode[] m_modes;
	static protected int currMode;
	static protected GameObject m_interface;
	static protected CharacterController m_characterController;
	

	void Start ()
	{

		m_GameMap = gameObject.AddComponent<GameMap>();
		m_GameMap.Initialise();
		m_players = new Player[2];
		m_players[0] = gameObject.AddComponent<Player>();
		m_players[1] = gameObject.AddComponent<Player>();
		Tile[] tempPlayer1 = { m_GameMap.GetTile (5, 6), m_GameMap.GetTile (5, 7),	m_GameMap.GetTile (5, 8),
			m_GameMap.GetTile (6, 7), m_GameMap.GetTile (6, 8)};
		Tile[] tempPlayer2 = {m_GameMap.GetTile (7, 7), m_GameMap.GetTile(8,7), m_GameMap.GetTile (8, 8)};
		m_players[0].Initialise(tempPlayer1, "Zhiyao");
		m_players [1].Initialise (tempPlayer2, "Oscar");
		currPlayer = 0;
		m_modes = new Mode[3];
		m_modes [0] = gameObject.AddComponent<PlayerMode>() as Mode;
		m_modes [0].Initialise ();
		m_modes[1] = gameObject.AddComponent<BuildMode>() as Mode;
		m_modes [1].Initialise ();
		m_modes [2] = gameObject.AddComponent<ArmyMode> () as Mode;
		m_modes [2].Initialise ();
		currMode = 1;
		m_modes[currMode].OnModeEnter();
		//Debug.Log("Castle "+(int)Structure.Castle +", Barracks " +(int)Structure.Barracks+", walls "+(int)Structure.Wall);
	}



	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0)) 
		{
			m_modes[currMode].OnClick ();
		} 
		else
		{
			m_modes[currMode].OnHover();
		}
	}


	public GameObject FindObjectUnderCursor()
	{
		Ray mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(mousePoint, out hit, 1000000, m_modes[currMode].GetLayerMask()))
		{
			return hit.transform.gameObject;
		} 
		else 
		{
			return null;
		}
	}	

	public void ChangeMode(int nextMode)
	{
		m_modes[currMode].OnModeExit();
		currMode = nextMode;
		m_modes[currMode].OnModeEnter();
	}

	public void OnGUI()
	{
		if (currMode != 1) 
		{
			if (GUI.Button (new Rect (10, 100, 150, 100), "Army")) 
			{
				ChangeMode (1);
			}
		}
		if (currMode != 2) 
		{
			if (GUI.Button (new Rect (10, 10, 150, 110), "Build")) 
			{
					ChangeMode (2);
			}
		}
		if (GUI.Button (new Rect (Screen.width-200, Screen.height-100, 150, 100), "End Turn, "+currPlayer+"'s turn"))
		{
			EndTurn();
		}
	}

	public void EndTurn()
	{
		m_modes[currMode].OnModeExit ();
		if((currPlayer+1) >= m_players.Length)
		{
			currPlayer = 0;
		}
		else
		{
			currPlayer ++;
		}
		m_modes[currMode].OnModeExit();
	}
}


