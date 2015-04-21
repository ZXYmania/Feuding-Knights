﻿using UnityEngine;
using System.Collections;

public enum Structure
{
	Castle,
	Barracks,
	Wall,
	Armoury,
	Mine,
	
}

public abstract class Building : MonoBehaviour 
{

	protected static int[] m_cost = {150, 10}; //Castle, Barracks
	public static int GetCost(Structure givenStructure)
	{

		return m_cost[(int)givenStructure];
	}
	public static int GetCost(Structure givenStructure, GameObject givenTile)
	{
		Debug.Log (givenTile.GetComponent<Tile> ().GetTerrain());
		switch (givenTile.GetComponent<Tile>().GetTerrain()) 
		{
			case Terrain.Water: return int.MaxValue;
			case Terrain.Mountain: return (m_cost[(int)givenStructure] + 100); 
			case Terrain.Hills:	return	m_cost[(int)givenStructure] + 25; 
			default: return m_cost[(int)givenStructure] + 0;
		}
	}

	protected Character m_owner;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Start()
	{
	//	int[] m_cost  
	}

	public override abstract string ToString();
}
