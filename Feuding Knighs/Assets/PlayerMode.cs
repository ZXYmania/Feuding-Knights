﻿using UnityEngine;
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
		givenTile.GetComponent<Tile>().Build(givenStructure);
		//givenTile.GetComponent<Renderer>().material = Resources.Load ("Castle") as Material;
		//m_building = gameObject.AddComponent<m_Building[0]> ();
	}

}