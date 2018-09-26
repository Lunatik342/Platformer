using UnityEngine;

public class GroundDetector : MonoBehaviour
{
	[SerializeField]
	private Transform[] detectionPoints;
	[SerializeField]
	private float detectionRadius;
	private LayerMask groundLayer;

	public bool isGrounded;

	void Start()
	{
		var l = LayerMask.NameToLayer(Constants.GroundLayerName);
		groundLayer  =  1 << l;
	}

	void FixedUpdate ()
	{
		isGrounded = false;
		for (var i = 0; i < detectionPoints.Length; i++)
		{
			isGrounded = isGrounded || Physics2D.OverlapCircle(detectionPoints[i].position, detectionRadius, groundLayer);
			if (isGrounded)
			{
				break;
			}
		}
	}
}
