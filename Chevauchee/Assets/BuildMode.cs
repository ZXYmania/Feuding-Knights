using UnityEngine;
using System.Collections;

public class BuildMode : Mode 
{
	public virtual void Initialise()
	{
		m_layerMask = 1 <<2 << 13;			//Ignore Units when drawing rays

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
				if(m_characterController.OwnsTile(currPlayer.GetCharacter(), cursorObj.GetComponent<Tile>()))
				{
					if(currPlayer.GetCharacter().SpendCash(Building.GetCost(Structure.Castle, cursorObj)))
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
		for(int i = 0; i < currPlayer.GetCharacter().TilesOwned(); i++) 
		{
			if(currPlayer.GetCharacter().GetTile(i).CanBuild(Structure.Castle))
			{
				Debug.Log(currPlayer.GetCharacter().GetTile(i).gameObject.ToString());
			}
			else
			{
				currPlayer.GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Can't Build");
			}
		}
	}

	public override void OnModeExit()
	{
		for(int i = 0; i < currPlayer.GetCharacter().TilesOwned(); i++) 
		{
			if(currPlayer.GetCharacter().GetTile(i).gameObject.layer == LayerMask.NameToLayer("Can't Build"))
			{
				currPlayer.GetCharacter().GetTile(i).gameObject.layer = LayerMask.NameToLayer("Tile");
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
			//givenTile.GetComponent<Renderer>().material = Resources.Load ("Castle") as Material;
			//m_building = gameObject.AddComponent<m_Building[0]> ();
		}
}
