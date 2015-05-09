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
		GameObject cursorObj = FindObjectUnder();
		if(cursorObj != null)
		{
			if(cursorObj.layer == LayerMask.NameToLayer("Tile")) 
			{

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

	}
	
	
	public override void UI()
	{
		
	}


}
