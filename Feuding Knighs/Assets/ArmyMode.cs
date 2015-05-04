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
		GameObject cursorObj = FindObjectUnderCursor();
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
		


}
