using UnityEngine;
using System.Collections;

public class ArmyMode : Mode
{
	Army selectedArmy;
	public override void Initialise()
	{
		m_layerMask = 1 << 2 ;
		m_layerMask = ~m_layerMask;
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
			if(cursorObj.layer == LayerMask.NameToLayer("Army")) 
			{
				Debug.Log("Found Unit");
				if(currPlayer.GetCharacter().OwnsArmy(cursorObj.GetComponent<Army>()))
				{
					selectedArmy = cursorObj.GetComponent<Army>();
					selectedArmy.gameObject.GetComponent<Renderer>().material = Resources.Load("ArmySelected") as Material;
					m_layerMask = (1 << 2)|(1 << 13);
					m_layerMask = ~m_layerMask;
				}
			}
			else if(cursorObj.layer == LayerMask.NameToLayer("Tile"))
			{
				if(selectedArmy != null)
				{
					if(selectedArmy.Move(cursorObj.transform.position))
					{
						selectedArmy.gameObject.GetComponent<Renderer>().material = Resources.Load("ArmyMoved") as Material;
						Debug.Log("Moved");
						selectedArmy = null;
						m_layerMask = 1 << 2;
						m_layerMask = ~m_layerMask;
					}
				}
				else
				{
					if(cursorObj.GetComponent<Tile>().GetBuilding() != null)
					{
						if(cursorObj.GetComponent<Tile>().GetBuilding().ToString() == "Castle")
						{
							if(cursorObj.GetComponent<Tile>().GetOwner()!= null)
							{
							if(currPlayer.GetCharacter().OwnsTile( cursorObj.GetComponent<Tile>()))
							{
									if(currPlayer.GetCharacter().SpendCash(cursorObj.GetComponent<Castle>().BuyArmy()))
									{
										cursorObj.GetComponent<Tile>().GetOwner().RaiseArmy(cursorObj.GetComponent<Tile>().GetPopulation(), cursorObj.transform.position);
									}
								}
							}
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
