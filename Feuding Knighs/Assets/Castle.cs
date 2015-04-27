using UnityEngine;
using System.Collections;

public class Castle : Building 
{
	public int garrison;

	public override Structure GetBuildingType()
	{
		return Structure.Castle;
	}

	public int BuyArmy(int givenPopulation)
	{
		return givenPopulation - garrison * cost;
	}
}
