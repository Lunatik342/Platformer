using System;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
	public BarrierController barrier;
	public event Action CharacterSmashed;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!barrier.isGoingUp && barrier.position != 0)
		{
			OnCharacterSmashed();
		}
	}

	private void OnCharacterSmashed()
	{
		if (CharacterSmashed != null)
		{
			CharacterSmashed();
		}
	}
}
