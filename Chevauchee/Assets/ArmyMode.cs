using UnityEngine;
using System.Collections;

public class ArmyMode : Mode
{
	Army selectedArmy;
	public virtual void Initialise()
	{
		m_layerMask = 1 <<2;
	}
	void Update()
	{

	}

	void Start()
	{
		base.Initialise();
	}

	public override void OnClick()
	{
		GameObject cursorObj = FindObjectUnderCursor();
		if(cursorObj != null)
		{
			if(cursorObj.layer == LayerMask.NameToLayer("Unit")) 
			{
				if(currPlayer.GetCharacter().OwnsArmy(cursorObj.GetComponent<Army>()))
				{

				}
			}
			else if(cursorObj.layer == LayerMask.NameToLayer("Tile"))
			{
				if(currPlayer.GetCharacter().OwnsTile(cursorObj.GetComponent<Tile>()))
				{
					if(cursorObj.GetComponent<Tile>().GetBuilding().ToString() == "Castle")
					{
						if(cursorObj.GetComponent<Character>()!= null)
						{
							cursorObj.GetComponent<Character>().RaiseGarrison(cursorObj.GetComponent<Tile>().GetPopulation());
						}

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

	}
		
	public override void OnModeExit()
	{

	}
		
		
	public void UI()
	{

	}
		
	private void Build(GameObject givenTile, Structure  givenStructure)
	{
			
	}

}
