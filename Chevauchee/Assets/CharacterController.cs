using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	Character[] m_characterList;

	public void AddCharacter(Character givenCharacter)
	{
		Character[] temp = new Character[m_characterList.Length + 1];
		for(int i = 0; i < m_characterList.Length; i++)
		{
			temp[i] = m_characterList[i];
		}
		temp [temp.Length-1] = givenCharacter;
		m_characterList = temp;
	}
	public void KillCharacter(){}

	public Character GetCharacter(Tile givenCapitalTile)
	{
		for (int i = 0; i < m_characterList.Length; i++) 
		{
			if(givenCapitalTile == m_characterList[i].GetCapitalTile())
			{
				return m_characterList[i];
			}
		}
		return null;
	}

	public bool OwnsTile(Character suspectedOwner, Tile givenTile)
	{
		if (suspectedOwner.OwnsTile (givenTile))
		{
			return true;
		} else 
		{
			for(int i = 0; i < suspectedOwner.AmountofUnderlings(); i++)
			{
				if(suspectedOwner.GetUnderling(i).OwnsTile(givenTile))
				{
					return true;
				}
			}
		}
		return false;

	}
}
