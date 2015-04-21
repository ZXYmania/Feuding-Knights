using UnityEngine;
using System.Collections;

public class Castle : Building 
{
	public void Initialise()
	{
		m_owner = gameObject.AddComponent<Character>();
	}

	public void Initialise(Character givenOwner)
	{
		m_owner = givenOwner;
	}

	public override string ToString ()
	{
		return "Castle";
	}
}
