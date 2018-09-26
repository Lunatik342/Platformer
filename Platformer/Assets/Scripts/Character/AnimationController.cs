using UnityEngine;

public class AnimationController : MonoBehaviour
{
	private GroundDetector _gndDetector;
	private Animator _animator;
	private Rigidbody2D _rigidbody;

	void Start()
	{
		_gndDetector = GetComponent<GroundDetector>();
		_animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (_gndDetector.isGrounded)
			_animator.SetBool("isGrounded", true);
		else
		{
			_animator.SetBool("isGrounded", false);
		}
		_animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
	}
}
