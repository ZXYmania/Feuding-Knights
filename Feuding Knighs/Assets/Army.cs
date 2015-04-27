using UnityEngine;
using System.Collections;

public class Army : MonoBehaviour 
{
	string m_ownerName;
	// Use this for initialization
	void Start () 
	{
		m_destination = transform.position;
		gameObject.layer = LayerMask.NameToLayer("Army");
		m_movementRate = 2;
	}

	public void Initialise(int givenSize)
	{
		m_size = givenSize;
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

	int m_size;
	float m_speed = 1;
	Character m_owner;
	int m_movementRate;
	bool moved;
	public Vector3 m_destination;

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
}
