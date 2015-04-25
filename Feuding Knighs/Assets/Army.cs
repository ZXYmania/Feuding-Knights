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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_destination - transform.position != Vector3.zero)
		{
			
			//transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.Normalize(moveTo - transform.position), speed*Time.deltaTime);
			if (Vector3.Magnitude (m_destination - transform.position) < m_speed * Time.deltaTime) {
				transform.position = m_destination;
			} else {
				transform.position += Vector3.Normalize (m_destination - transform.position) * m_speed * Time.deltaTime;
			}
		}
	}

	int size;
	int efficiency;
	float m_speed = 1;
	Character m_owner;
	int movementRate;
	bool moved;
	public Vector3 m_destination;

	public void Move(Vector3 givenDestination)
	{
		if (!moved)
		{
			m_destination = new Vector3( givenDestination.x, gameObject.transform.position.y, givenDestination.z);
			moved = true;
		}
	}
}
