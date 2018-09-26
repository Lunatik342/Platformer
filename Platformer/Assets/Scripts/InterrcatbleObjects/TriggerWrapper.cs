using System;
using UnityEngine;

public class TriggerWrapper : MonoBehaviour
{
	public int charactersInside;
	public event Action<int> CharactersInsideChanged;

	void OnTriggerEnter2D()
	{
		charactersInside++;
		OnStateChanged();
	}

	void OnTriggerExit2D()
	{
		charactersInside--;
		OnStateChanged();
	}

	protected virtual void OnStateChanged()
	{
		if (CharactersInsideChanged != null)
		{
			CharactersInsideChanged(charactersInside);
		}
	}
}
