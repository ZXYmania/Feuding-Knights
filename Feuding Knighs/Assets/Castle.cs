using UnityEngine;
using System.Collections;

public class Castle : Building 
{
	public override string ToString ()
	{
		return "Castle";
	}
	public int BuyArmy()
	{
		return 20;
	}
}
