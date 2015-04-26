using UnityEngine;
using System.Collections;


public enum Terrain
{
	Hills,
	Mountain,
	Forest,
	Plains,
	Desert,
	Tundra,
	Water,
	
}

public class Tile : MonoBehaviour 
{

	Building m_building;
	Industry m_industry;
	int m_population;
	Terrain m_terrain;
	public Character m_owner;

	public Terrain GetTerrain(){return m_terrain;}
	public Building GetBuilding(){return m_building;}
	public int GetPopulation(){return m_population;}
	public void SetOwner(Character givenOwner){m_owner = givenOwner;}
	public Character GetOwner(){return m_owner;}

	public void Initialise()
	{
		GetRandomTerrain ();
		gameObject.GetComponent<Renderer>().material = Resources.Load(m_terrain.ToString()) as Material;
		gameObject.layer = LayerMask.NameToLayer("Tile");
		m_population = Random.Range(100, 600);

	}

	public bool CanBuild(Structure givenStructure)
	{
		if (m_building == null) 
		{
			if(m_terrain != Terrain.Water)
			{
				return true;
			}
		}
		return false;
	}

	public void Build(Structure givenStructure)
	{
		switch(givenStructure)
		{
			case Structure.Castle: m_building = gameObject.AddComponent<Castle>();
									break;
			default : break;
		}
		gameObject.GetComponent<Renderer>().material = Resources.Load(m_building.ToString()) as Material;
	}

	//public string GetPlayerName(){return m_ownerName;}
	
	public void GetRandomTerrain()
	{
		m_terrain = (Terrain)Random.Range (0, 7);

	}
	// Update is called once per frame
	void Update () 
	{
	
	}

	public int GatherIndustry()
	{
		//Find Total industry and tell the player what was earnt
		return 0;
	}

	public int RaiseArmy()
	{
		//Find population and return that number to the player
		return 0;
	}

	public void Conquered()
	{
		//Change Player Owned
	}

	public int Loot()
	{
		//Take money from the region and receive all ill effects
		return 0;
	}

}
