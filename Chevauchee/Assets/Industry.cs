using UnityEngine;
using System.Collections;



public class Industry : MonoBehaviour 
{


	public enum Industries
	{
		Fish,
		Wheat,
		Gold,
		Copper,
		Iron,
		Lumber,

	}

	public Industries GetRandomIndustry()
	{
		switch(Random.Range(0, 5))
		{
			case 0: return Industries.Fish;
			case 1: return Industries.Wheat;
			case 2 : return Industries.Gold;
			case 3: return Industries.Copper;
			case 4: return Industries.Iron;
			case 5: return Industries.Lumber;
			default: return Industries.Wheat;
		}
	}

	int quantity;	//Amount of Industry produced 
	int level;		//Ability to produce Industry or Quaity of Industry Produced
}
