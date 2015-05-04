using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	static Character[] characterList;
	public static void AddCharacter(Character givenCharacter)
	{
		if (characterList != null)
		{
			Character[] temp = new Character[characterList.Length + 1];
			for (int i = 0; i < characterList.Length; i++) {
				temp [i] = characterList [i];
			}
			temp [temp.Length - 1] = givenCharacter;
			characterList = temp;
		} 
		else
		{
			characterList = new Character[1];
			characterList[0] = givenCharacter;
		}
	}
	
	public static Character GetCharacter(Tile givenCapitalTile)
	{
		for (int i = 0; i < characterList.Length; i++) 
		{
			if(givenCapitalTile == characterList[i].GetCapitalTile())
			{
				return characterList[i];
			}
		}
		return null;
	}
	
	protected Tile[] m_ownedTile;
	protected Character[] m_underLing;
	protected Character m_overlord;
	protected GameObject[] m_army;
	
	public int AmountofUnderlings(){return m_underLing.Length;}
	public Character GetUnderling(int index){return m_underLing [index];}
	
	protected Ledger m_ledger;
	protected int m_cash;
	protected int[] m_exports;
	
	public int GetCash(){return m_cash;}
	public bool SpendCash(int spendingCost)
	{
		if(m_cash > spendingCost) 
		{
			m_cash -= spendingCost;
			Debug.Log("cost "+m_cash);
			return true;
		}
		Debug.Log ("No Money");
		return false;
	}
	
	public Tile GetTile(int index){	return m_ownedTile[index];}
	public Tile GetCapitalTile(){return m_ownedTile [0];}
	public int TilesOwned(){return m_ownedTile.Length;}
	
	public void AddTile(Tile givenTile)
	{
		Tile[] temp = new Tile[m_ownedTile.Length + 1];
		for(int i = 0; i < m_ownedTile.Length; i++)
		{
			temp[i] = m_ownedTile[i];
		}
		temp [temp.Length-1] = givenTile;
		m_ownedTile = temp;
		givenTile.SetOwner(this);
	}
	
	public bool OwnsTile(Tile givenTile)
	{
		if (m_underLing != null) 
		{
			for (int i=0; i < m_underLing.Length; i++) {
				if (m_underLing [i].OwnsTile (givenTile)) {
					return true;
				}
			}
		}
		for (int i = 0; i < m_ownedTile.Length; i++)
		{
			if(givenTile == m_ownedTile[i])
			{
				return true;
			}
		}
		Debug.Log ("You do not own the selected tile");
		return false;
	}
	
	/*	public bool OwnsTile(Character suspectedOwner, Tile givenTile)
	{
		if (suspectedOwner.OwnsTile(givenTile))
		{
			return true;
		} else 
		{
			for(int i = 0; i < suspectedOwner.AmountofUnderlings(); i++)
			{
				if(suspectedOwner.GetUnderling(i).OwnsTile(givenTile))
				{
					return true;
				}
			}
		}
		return false;
		
	}*/
	
	
	public bool OwnsArmy(Army givenArmy)
	{
		if (m_underLing != null) 
		{
			for (int i=0; i < m_underLing.Length; i++) {
				if (m_underLing [i].OwnsArmy(givenArmy)) {
					return true;
				}
			}
		}
		for(int i = 0; i < m_army.Length; i++)
		{
			if(givenArmy == m_army[i].GetComponent<Army>())
			{
				return true;
			}
		}
		Debug.Log ("You do not own the selected army");
		return false;
	}
	public void AddArmy(int givenSize, Soldier givenCompany, Vector3 tilePos)
	{
		if (m_army != null) 
		{
			GameObject[] temp = new GameObject[m_army.Length + 1];
			for(int i = 0; i < m_army.Length; i++)
			{
				temp[i] = m_army[i];
			}
			temp[temp.Length-1] = Instantiate(Resources.Load("Army"), new Vector3(tilePos.x, 1, tilePos.z), Quaternion.identity) as GameObject;
			temp[temp.Length-1].AddComponent<Army>();
			m_army = temp;
			
		} 
		else
		{
			m_army = new GameObject[1];
			m_army[0] = Instantiate(Resources.Load("Army"), new Vector3(tilePos.x, 1, tilePos.z), Quaternion.identity) as GameObject;
			m_army[0].AddComponent<Army>();
		}
		m_army[m_army.Length - 1].GetComponent<Army>().Initialise();
		m_army[m_army.Length - 1].GetComponent<Army>().AddCompany(givenSize, givenCompany);
	}
	public void Initialise(Tile[] startingTile)
	{
		m_ownedTile = new Tile[1];
		m_ownedTile [0] = startingTile[0];
		m_cash = 400;
		startingTile[0].SetOwner(this);
		AddCharacter(this);
		GetTile(0).Build(Structure.Castle);
		for (int i = 1; i < startingTile.Length; i++) 
		{
			AddTile(startingTile[i]);
		}
	}
	
	
	
	void Update ()
	{
		
	}
	
	public void IncomePhase()
	{
		//For each owned tile
		//Increase Cash by money earnt through resources
		//Decrese Cash by expenses
		//Gain Money from your underlings
	}
	
	
}
