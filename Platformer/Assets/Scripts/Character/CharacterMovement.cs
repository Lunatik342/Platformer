using UnityEngine;


[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
	public MovementSet set;
	public float speed = 5f;
	public float jumpForce = 135f;
	public float jumpDelay = 0.5f;

	private Rigidbody2D _rigidbody;
	private GroundDetector _gndDetector;
	private bool _facingRight = true;
	private bool _jump;
	private float _timeLeft;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_gndDetector = GetComponent<GroundDetector>();
	}

	void Update()
	{
		CheckJumpConditions();
	}

	void FixedUpdate()
	{
		MoveHorizontaly();
		Jump();
	}

	private void MoveHorizontaly()
	{
		float h = Input.GetAxis(set.HorizontalMovementAxis);
		_rigidbody.velocity = new Vector2(h * speed, _rigidbody.velocity.y);
		if (h > 0 && !_facingRight)
			Flip();
		else if (h < 0 && _facingRight)
			Flip();
	}

	private void Jump()
	{
		if (_jump)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
			_jump = false;
		}
	}

	private void CheckJumpConditions()
	{
		if (_timeLeft >= 0f)
			_timeLeft = _timeLeft - Time.deltaTime;
		else
		{
			bool pressed = Input.GetButton(set.VerticalMovementAxis);
			if (pressed && _gndDetector.isGrounded)
			{
				_jump = true;
				_timeLeft = jumpDelay;
			}
		}
	}

	void Flip()
	{
		_facingRight = !_facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
