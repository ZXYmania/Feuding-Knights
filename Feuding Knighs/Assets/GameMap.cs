using UnityEngine;
using System.Collections;

public class GameMap : MonoBehaviour 
{
	private GameObject[,]  m_Map;
	// Use this for initialization
	public Tile GetTile(int givenX, int givenY) {return m_Map[givenX, givenY].GetComponent<Tile>();}
	public Tile GetTile(int givenIndex) {return m_Map[givenIndex / 10, givenIndex % 10].GetComponent<Tile>();} 
	public int GetSquareLength(){return m_Map.Length;}


	void Start () 
	{

	}

	public void Initialise()
	{
		m_Map = new GameObject[10,10];
		//m_Map = new GameObject[10][10];
		for(int i = 0; i < 10; i++)
		{
			for(int j = 0; j < 10; j++)
			{
				m_Map[i,j] = Instantiate( Resources.Load("Tile"), new Vector3(i, 0, j), Quaternion.identity) as GameObject;
				m_Map[i,j].GetComponent<Tile>().Initialise();
				m_Map[i,j].gameObject.name = "Tile " + i+", " +j;
			}
		}
		//Initialise each tile semi randomly
		

	}

	void GenerateMap()
	{

	}
	// Update is called once per frame
	void Update () 
	{

	}
}
