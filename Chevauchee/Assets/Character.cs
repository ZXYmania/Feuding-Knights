using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	protected Tile[] m_ownedTile;
	protected Character[] m_underLing;
	protected Character m_overlord;

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
			Debug.Log(m_cash);
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
	}

	public bool OwnsTile(Tile givenTile)
	{
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



	public bool OwnsArmy(Army givenArmy)
	{
		/*for(int i = 0; i < ; i++)
		{
			if(givenTile == m_ownedTile[i])
			{
				return true;
			}
		}*/
		return false;
	}

	public void Initialise(Tile capitalTile)
	{
		m_ownedTile = new Tile[1];
		m_ownedTile [0] = capitalTile;
		m_cash = 400;
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

	public void RaiseGarrison(int basePopulation)
	{
		//Raise troops based on armaments, population
	}
}
