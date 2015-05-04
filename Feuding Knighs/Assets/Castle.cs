using UnityEngine;
using System.Collections;

public class Castle : Building 
{
	public int[] garrison;
	public int GetGarrison(int givenIndex){return garrison[givenIndex];}
	public override string ToString(){return "Castle";} 


	public override void Initialise(int givenPopulation)
	{
		garrison = new int[2];
		garrison[0] = (int)givenPopulation/10;
		garrison [1] = (int)givenPopulation/20;
	}
	public override Structure GetBuildingType()
	{
		return Structure.Castle;
	}

	/*public Army RaiseGarrison(int givenPopulation, int givenCost, Character givenCharacter)
	{

			(givenPopulation - garrison) * givenCost;
	}*/
}
