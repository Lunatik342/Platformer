using System.Collections;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
	public TriggerWrapper[] interractbleObjects;

	public float speedGoingUp = 0.5f;
	public float speedGoingDown = 1f;
	public float upStateHight = 5f;

	private Vector3 _upPosition;
	private Vector3 _startPosition;
	private Transform _transform;

	public bool isGoingUp;
	public float position;

	private bool _isNotReached;

	void Start()
	{
		_startPosition = transform.position;
		_upPosition = _startPosition + new Vector3(0, upStateHight, 0);
		_transform = transform;
	}

	void OnEnable()
	{
		for (int i = 0; i < interractbleObjects.Length; i++)
		{
			interractbleObjects[i].CharactersInsideChanged += CheckMoveConditions;
		}
	}

	void OnDisable()
	{
		for (int i = 0; i < interractbleObjects.Length; i++)
		{
			interractbleObjects[i].CharactersInsideChanged -= CheckMoveConditions;
		}
	}

	private void CheckMoveConditions(int n)
	{
		var charsInside = 0;
		for (int i = 0; i < interractbleObjects.Length; i++)
		{
			charsInside = charsInside + interractbleObjects[i].charactersInside;
		}
		isGoingUp = charsInside > 0;

		if (!_isNotReached)
		{
			StartCoroutine(Move());
		}
	}

	private IEnumerator Move()
	{
		_isNotReached = true;
		while (_isNotReached)
		{
			MoveToCertainDirection();
			yield return null;
		}
	}

	private void MoveToCertainDirection()
	{
		float maxPos;
		int sign;

		if (isGoingUp)
		{
			maxPos = 1f;
			sign = 1;
		}
		else
		{
			maxPos = 0f;
			sign = -1;
		}

		if (position != maxPos)
		{
			position = Mathf.Clamp01(position = position + sign * speedGoingDown * Time.deltaTime);
			_transform.position = Vector3.Lerp(_startPosition, _upPosition, position);
		}
		else
		{
			_isNotReached = false;
		}
	}


}
