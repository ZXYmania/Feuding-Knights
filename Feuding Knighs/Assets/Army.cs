using UnityEngine;
using System.Collections;

public enum Soldier
{
	MenatArms,
	Knight,
	Archer,
	None
}

public class Army : MonoBehaviour 
{
	int m_size;
	public int GetSize(){return m_company.Length;}
	int m_cost;
	public int GetCost(){return m_cost;}
	float m_speed = 1;
	Character m_owner;
	public Character GetOwner(){return m_owner;}
	int m_movementRate;
	bool moved;
	protected Vector3 m_destination;
	
	protected Company[] m_company;
	public Company[] GetCompany(){return m_company;}

	public static int GetCost(int givenPopulation, Soldier givenUnit)
	{
		switch (givenUnit)
		{
			case Soldier.MenatArms: return 5;
			default: return -1;
		}
	}

	public void Destroy()
	{
		for (int i = 0; i < m_company.Length; i++)
		{
			Destroy(m_company[i]);
		}
	}
/*	public static void CombineArmies(Army myArmy, Army armyCollidedWith)
	{
		for(int i = 0; 
	}*/

	public void Initialise(Character givenOwner)
	{
		m_destination = transform.position;
		gameObject.layer = LayerMask.NameToLayer("Army");
		m_movementRate = 2;
		m_owner = givenOwner;
		m_size = 0;
	}
	// Update is called once per frame
	void Update () 
	{
		if (m_destination - transform.position != Vector3.zero)
		{
			
			//transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.Normalize(moveTo - transform.position), speed*Time.deltaTime);
			if (Vector3.Magnitude (m_destination - transform.position) < m_speed * Time.deltaTime) 
			{
				transform.position = m_destination;
			} 
			else
			{
				transform.position += Vector3.Normalize (m_destination - transform.position) * m_speed * Time.deltaTime;
			}
		}
	}
	
	public bool Move(Vector3 givenDestination)
	{
		givenDestination = new Vector3(givenDestination.x, transform.position.y,givenDestination.z);
		if (!moved && Vector3.Magnitude(givenDestination-transform.position)<= m_movementRate)
		{
			m_destination = new Vector3( givenDestination.x, gameObject.transform.position.y, givenDestination.z);
			moved = true;
		}
		return moved;
	}

	public void AddCompany(int givenSize, Soldier givenType)
	{
		if(m_company != null)
		{
			Company[] temp = new Company[m_company.Length + 1];
			for(int i = 0; i < m_company.Length; i++)
			{
				temp[i] = m_company[i];
			}
			temp[temp.Length-1] = gameObject.AddComponent<Company>();
			m_company = temp;
			
		} 
		else
		{
			m_company = new Company[1];
			m_company[0] = gameObject.AddComponent<Company>();
		}
		m_company[m_company.Length - 1].Initialise(givenSize, givenType);
	}
	public void AddCompany(Company[] givenArmy)
	{
		Company[] temp = new Company[m_company.Length + givenArmy.Length];
		Debug.Log ("Temp lemgth "+m_company.Length + givenArmy.Length);

		int i = 0;
		for(;i < m_company.Length; i++)
		{
			Debug.Log("I: "+i);
			temp[i] = m_company[i];
		}
		for(int j = 0;i < m_company.Length + givenArmy.Length; i++)
		{
			Debug.Log("I: "+i +", J: " + j);
			temp[i] = givenArmy[j];
			j++;
		}
		m_company = temp;
		Debug.Log("Company size " +GetSize ());
	}
}
