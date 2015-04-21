using UnityEngine;
using System.Collections;

public class PlayerMode : Mode 
{
	public virtual void Initialise()
	{
		m_layerMask = 1 << 2;
	}
	void Update()
	{
		
	}
	protected Building[] m_Building;
	void Start()
	{
		base.Initialise();
	}
	
	public override void OnClick()
	{
		GameObject cursorObj = FindObjectUnderCursor();
		if(cursorObj != null)
		{
			if(cursorObj.layer == LayerMask.NameToLayer("Tile")) 
			{
				if(currPlayer.OwnsTile(cursorObj.GetComponent<Tile>()))
				{
					if(currPlayer.SpendCash(Building.GetCost(Structure.Castle, cursorObj)))
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
		for(int i = 0; i < currPlayer.TilesOwned(); i++) 
		{
			if(currPlayer.GetTile(i).CanBuild(Structure.Castle))
			{
				Debug.Log(currPlayer.GetTile(i).gameObject.ToString());
			}
			else
			{
				currPlayer.GetTile(i).gameObject.layer = LayerMask.NameToLayer("Can't Build");
			}
		}
	}
	
	public override void OnModeExit()
	{
		for (int i = 0; i < m_GameMap.GetSquareLength(); i++)
		{
			for (int j = 0; j < m_GameMap.GetSquareLength(); j++) 
			{
				if(m_GameMap.GetTile(i,j).gameObject.layer == LayerMask.NameToLayer("Can't Build"))
				{
					m_GameMap.GetTile(i,j).gameObject.layer = LayerMask.NameToLayer("Tile");
				}
			}
			
		}
	}
	
	
	public void UI()
	{
		
	}
	
	private void Build(GameObject givenTile, Structure  givenStructure)
	{
		givenTile.GetComponent<Tile>().Build(givenStructure);
		//givenTile.GetComponent<Renderer>().material = Resources.Load ("Castle") as Material;
		//m_building = gameObject.AddComponent<m_Building[0]> ();
	}

}
