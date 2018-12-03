using UnityEngine;

/// <summary>
/// Player movement and controls
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] float _jumpAccel = 10f;
    public float _speed = 10f;

    [SerializeField] float _obstacleSlowDown = 0.2f;

    public float _accumulatedPenalty = 0f;

    Rigidbody _rb;

	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        if (GameLogic.Instance.State != GameLogic.GameState.Running)
        {
            // freeze RB in place
            _rb.isKinematic = true;
            return;
        }

        // gravity switches direction when player crosses y=5
        float gravityDir = transform.position.y > 5f ? 1f : -1f;
        Physics.gravity = gravityDir * Vector3.up * 20f;

        if (Input.GetButton("Jump") || Input.GetMouseButton(0))
        {
            _rb.AddForce(-Physics.gravity, ForceMode.Acceleration);
            _rb.AddForce(_jumpAccel * Vector3.up * Mathf.Sign(Physics.gravity.y) * -1f, ForceMode.Acceleration);
        }
    }

    void Update ()
    {
        if (GameLogic.Instance.State != GameLogic.GameState.Running)
        {
            // freeze RB in place
            _rb.isKinematic = true;
            return;
        }

        // adjust speed based on current overlap pickup state.
        // inside amount will be positive for bad pickups and negative for good pickups.
        float speed = _speed - _obstacleSlowDown * _accumulatedPenalty;
        transform.position += speed * Time.deltaTime * Vector3.right;
    }
}
