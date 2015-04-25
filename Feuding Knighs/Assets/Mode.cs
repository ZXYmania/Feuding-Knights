using UnityEngine;
using System.Collections;

public abstract class Mode : GameLogic
{
	public virtual void Initialise()
	{
		m_layerMask = 1 << 2;
		m_layerMask = ~m_layerMask;
	}

	protected int m_layerMask;
	public abstract void OnClick();
	public abstract void OnHover();
	public abstract void OnModeEnter();
	public abstract void OnModeExit();
	public int GetLayerMask(){return m_layerMask;}

}
