using UnityEngine;
using System.Collections;

public class Company : MonoBehaviour 
{

	public int m_size;
	Soldier m_type;
	public int GetSize(){return m_size;}
	public Soldier GetType(){return m_type;}

	public void Initialise(int givenSize, Soldier givenType)
	{
		m_size = givenSize;
		m_type = givenType;
	}
	public void Initialise(Company givenCompany)
	{
		m_size = givenCompany.GetSize();
		m_type = givenCompany.GetType();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
