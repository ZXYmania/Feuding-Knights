﻿using UnityEngine;
using System.Collections;

public class BuildMode : Mode 
{
	Structure selectedBuilding;
	bool selectedArmy;
	
	public override void Initialise()
	{
		m_layerMask = (1 << 2) | (1 << 14);	
		m_layerMask = ~m_layerMask;
	}
	
	protected Building[] m_Building;
	void Start()
	{
		selectedArmy = false;
		selectedBuilding = Structure.None;
	}
	
	public override void OnClick()
	{
		GameObject cursorObj = FindObjectUnder();
		if(cursorObj != null)
		{
			if(selectedBuilding != Structure.None)
			{
				if(cursorObj.layer == LayerMask.NameToLayer("Tile")) 
				{
					if(m_players[currPlayer].GetCharacter().OwnsTile( cursorObj.GetComponent<Tile>()))
					{
						if(cursorObj.GetComponent<Tile>().CanBuild(selectedBuilding))
						{
							if(m_players[currPlayer].GetCharacter().SpendCash(Building.GetCost(selectedBuilding, cursorObj)))
							{
								Build(cursorObj, selectedBuilding);
							}
						}
					}
				}
			}
			if(selectedArmy)
			{
				if(cursorObj.layer == LayerMask.NameToLayer("Building"))
				{
					if(m_players[currPlayer].GetCharacter().OwnsTile(cursorObj.GetComponent<Tile>()))
					{
						switch(cursorObj.GetComponent<Building>().GetBuildingType())
						{
							case Structure.Castle : RaiseGarrison(cursorObj);
							break;
							default: break;
						}
					}
				}
			}
		}
	}
	
	public override void OnHover()
	{
		GameObject cursorObj = FindObjectUnder();
		if (cursorObj != null) 
		{
			
		}
	}
	
	public override void OnModeEnter()
	{
		for(int i = 0; i < m_players[currPlayer].GetCharacter().TilesOwned(); i++) 
		{
			if(m_players[currPlayer].GetCharacter().GetTile(i).GetBuilding() != null)
			{
				m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Building");
			}
			else
			{
				Debug.Log(m_players[currPlayer].GetCharacter().GetTile(i).gameObject.ToString());
			}
		}
		selectedArmy = false;
		selectedBuilding = Structure.None;
	}
	
	public override void OnModeExit()
	{
		for(int i = 0; i < m_players[currPlayer].GetCharacter().TilesOwned(); i++) 
		{
			if(m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer == LayerMask.NameToLayer("Building"))
			{
				m_players[currPlayer].GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Tile");
			}
			else
			{
				
			}
		}
		selectedArmy = false;
		selectedBuilding = Structure.None;
	}
	
	
	public override void UI()
	{
		if (selectedBuilding != Structure.Castle) 
		{
			if (GUI.Button (new Rect (10, Screen.height - 100, 150, 100), "Castle")) 
			{
				selectedBuilding = Structure.Castle;
				selectedArmy = false;
			}
		}
		if (!selectedArmy) 
		{
			
			if (GUI.Button (new Rect (170, Screen.height - 100, 150, 100), "Army"))
			{
				selectedArmy = true;
				selectedBuilding = Structure.None;
			}
		}
	}
	
	private void Build(GameObject givenTile, Structure  givenStructure)
	{
		givenTile.GetComponent<Tile>().Build(givenStructure);
		givenTile.gameObject.layer = LayerMask.NameToLayer("Building");
	}
	private void RaiseGarrison(GameObject cursorObj)
	{
		Character tempChar = cursorObj.GetComponent<Tile>().GetOwner();
		int armySize = 0;
		for(int i = 0; i < tempChar.TilesOwned(); i++) 
		{
			Debug.Log(i + " :"+ tempChar.GetTile(i).GetPopulation());
			armySize += tempChar.GetTile(i).GetPopulation();
		}
		Debug.Log ("Gar: " + cursorObj.GetComponent<Castle> ().GetGarrison (0));
		if (m_players [currPlayer].GetCharacter().SpendCash(Army.GetCost(armySize, Soldier.MenatArms))) 
		{
			//Raise troops based on armaments, population
			m_players[currPlayer].GetCharacter().AddArmy(armySize + cursorObj.GetComponent<Castle>().GetGarrison(0), Soldier.MenatArms, cursorObj.transform.position);
			
		} 
	}
}
