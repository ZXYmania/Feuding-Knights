using UnityEngine;
using System.Collections;

public class BuildMode : Mode 
{
	public override void Initialise()
	{
		m_layerMask = (1 << 2)|(1 << 13)|(1 << 19);			//Ignore Units when drawing rays
		m_layerMask = ~m_layerMask;
	}
	void Update()
	{

	}
	protected Building[] m_Building;
	void Start()
	{

	}

	public override void OnClick()
	{
		GameObject cursorObj = FindObjectUnderCursor();
		if(cursorObj != null)
		{
			if(cursorObj.layer == LayerMask.NameToLayer("Tile")) 
			{
				if(m_players[currPlayer].GetCharacter().OwnsTile( cursorObj.GetComponent<Tile>()))
				{
					if(m_players[currPlayer].GetCharacter().SpendCash(Building.GetCost(Structure.Castle, cursorObj)))
					{
						Build(cursorObj, Structure.Castle);
					}
				}
			}
		}
	}

	public override void OnHover()
	{
		GameObject cursorObj = FindObjectUnderCursor();
		if (cursorObj != null) 
		{

		}
	}

	public override void OnModeEnter()
	{
		for(int i = 0; i < m_players[currPlayer].GetCharacter().TilesOwned(); i++) 
		{
			if(m_players[currPlayer].GetCharacter().GetTile(i).CanBuild(Structure.Castle))
			{
				Debug.Log(m_players[currPlayer].GetCharacter().GetTile(i).gameObject.ToString());
			}
			else
			{
				m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Can't Build");
			}
		}
	}

	public override void OnModeExit()
	{
		for(int i = 0; i < m_players[currPlayer].GetCharacter().TilesOwned(); i++) 
		{
			if(m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer == LayerMask.NameToLayer("Can't Build"))
			{
				m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Tile");
			}
			else
			{

			}
		}
	}


	public void UI()
	{

	}
	
		private void Build(GameObject givenTile, Structure  givenStructure)
		{
			givenTile.GetComponent<Tile>().Build(givenStructure);
			givenTile.gameObject.layer = LayerMask.NameToLayer("Can't Build");
		}
}
