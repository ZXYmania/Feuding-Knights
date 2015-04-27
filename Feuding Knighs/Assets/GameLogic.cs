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
	static float cameraSpeed;
	public GameObject mainlight;
	

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
		m_modes[0] = gameObject.AddComponent<PlayerMode>() as Mode;
		m_modes[0].Initialise ();
		m_modes[1] = gameObject.AddComponent<BuildMode>() as Mode;
		m_modes[1].Initialise ();
		m_modes[2] = gameObject.AddComponent<ArmyMode> () as Mode;
		m_modes[2].Initialise ();
		currMode = 0;
		m_modes[currMode].OnModeEnter();
		cameraSpeed = 5;
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
		MoveCamera ();
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
			if (GUI.Button (new Rect (10, 120, 150, 100), "Build")) 
			{
				ChangeMode (1);
			}
		}
		if (currMode != 2) 
		{
			if (GUI.Button (new Rect (10, 10, 150, 110), "Army")) 
			{
					ChangeMode (2);
			}
		}
		if (GUI.Button (new Rect (Screen.width-200, Screen.height-100, 150, 100), "End Turn, "+currPlayer+"'s turn"))
		{
			EndTurn();
		}
		m_modes[currMode].UI();
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
		currMode = 0;
		m_modes [currMode].OnModeEnter();
	}

	public void MoveCamera()
	{
		Vector3 movevector = Vector3.zero;
		if (Input.GetKey (KeyCode.W)) 
		{
			movevector.z +=1;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			movevector.z -=1;
		}
		if (Input.GetKey (KeyCode.A))
		{
			movevector.x -=1;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			movevector.x +=1;
		}
		if (Input.GetKey (KeyCode.Q)) 
		{

			if((cameraSpeed-1 * Time.deltaTime) > 5)
			{
				gameObject.GetComponent<Camera>().orthographicSize -= 1 * Time.deltaTime;
				cameraSpeed -= 1 * Time.deltaTime;
			}
		}
		if (Input.GetKey (KeyCode.E)) 
		{
			gameObject.GetComponent<Camera>().orthographicSize+= 1 * Time.deltaTime;
			cameraSpeed += 1 * Time.deltaTime;;
		}
		transform.position += Vector3.Normalize (movevector) * cameraSpeed * Time.deltaTime;
		mainlight.transform.position = transform.position;
	}
}


