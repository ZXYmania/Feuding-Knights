using UnityEngine;
using System.Collections;

public class Company : MonoBehaviour
{
	int m_size;
	Soldier m_type;

	public void Initialise(int givenSize, Soldier givenType)
	{
		m_size = givenSize;
		m_type = givenType;
	}

}
