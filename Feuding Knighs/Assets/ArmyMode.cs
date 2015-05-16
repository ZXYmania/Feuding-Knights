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


	void Start()
	{
		base.Initialise();
	}

	public override void OnClick()
	{
		GameObject cursorObj = FindObjectUnder();
		if(cursorObj != null)
		{
			if(cursorObj.layer == LayerMask.NameToLayer("Army")) 
			{
				Debug.Log("Found Army");
				if(m_players[currPlayer].GetCharacter().OwnsArmy(cursorObj.GetComponent<Army>()))
				{
					selectedArmy = cursorObj.GetComponent<Army>();
					selectedArmy.gameObject.GetComponent<Renderer>().material = Resources.Load("ArmySelected") as Material;
					m_layerMask = (1 << 2)|(1 << 14);
					m_layerMask = ~m_layerMask;
				}
			}
			else if(cursorObj.layer == LayerMask.NameToLayer("Tile"))
			{
				if(selectedArmy != null)
				{
					LayerMask armyMask = (1<< 14);
					Vector3 aboveDestinationTile = new Vector3(cursorObj.transform.position.x, cursorObj.transform.position.y+5, cursorObj.transform.position.z);
					GameObject collidedArmyObj = FindObjectUnder(aboveDestinationTile, armyMask);
					if(collidedArmyObj == null)
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
						if(ArmiesCollide(selectedArmy, collidedArmyObj.GetComponent<Army>()))
						{
							Debug.Log("Merged");
							selectedArmy = null;
							m_layerMask = 1 << 2;
							m_layerMask = ~m_layerMask;
						}
					}
				}
				else
				{

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

	}
		
	public override void OnModeExit()
	{
		if (selectedArmy != null) 
		{
			selectedArmy.gameObject.GetComponent<Renderer> ().material = Resources.Load ("ArmyMoved") as Material;
			selectedArmy = null;
			m_layerMask = 1 << 2;
			m_layerMask = ~m_layerMask;
		}
	}
		
		
	public override void UI()
	{
		if (selectedArmy != null)
		{
			GUI.Label(new Rect (Screen.width-160, 100, 150, 100),"Army size"+ selectedArmy.GetSize());
		}
	}

	public bool ArmiesCollide(Army myArmy, Army armyCollidedWith)
	{
		if (myArmy.GetOwner() != armyCollidedWith.GetOwner ()) 
		{
			//Battle 
			Debug.Log("Battle");
			return true;
		} 
		else if(myArmy != armyCollidedWith)
		{ 
			armyCollidedWith.AddCompany(myArmy.GetCompany());	//Add this army to the already existing army
			myArmy.GetOwner().RemoveArmy(myArmy);	//Remove this army
			return true;
		}
		return false;
	}

	public void BattleArmy(Army myArmy, Army armyCollidedWith)
	{
		int tempRand = Random.Range(0, 100);
		if (tempRand > 90)
		{
			// major victory armyCollidedWith
		} 
		else if (tempRand > 70)
		{
			// decisive victory armyCollidedWith
		} else if (tempRand > 50)
		{
			//Retreat made by myarmy
		}
		else if (tempRand > 30)
		{
			//retreat made by armycollidedwith
		}
		else if (tempRand > 10)
		{
			//decisive victory made by myarmy
		}
		else
		{
			//major victory made by my army
		}
	}

}
