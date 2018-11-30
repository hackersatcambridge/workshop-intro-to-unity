using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0f, 60f)]
    public float _speed = 60f;

    public Vector3 _jumpInitialVelocity = Vector3.up * 10f;

    enum JumpState
    {
        NotJumping,
        Jumping,
    }
    JumpState _jumpState = JumpState.NotJumping;

    Vector3 _velocity = Vector3.zero;

    void Update ()
    {
        if(!GameLogic.Instance.PlayerAlive)
        {
            return;
        }

        transform.position += _speed * Vector3.forward * Time.deltaTime;

        switch(_jumpState)
        {
            case JumpState.NotJumping:

                if (Input.GetButtonDown("Jump"))
                {
                    // switch to jumping
                    Debug.Log("Started jumping");

                    _velocity = _jumpInitialVelocity;

                    _jumpState = JumpState.Jumping;
                }

                break;
            case JumpState.Jumping:
                transform.position += _velocity * Time.deltaTime;
                _velocity += Physics.gravity * Time.deltaTime;
                
                if(transform.position.y <= 1f)
                {
                    var pos = transform.position;
                    pos.y = 1f;
                    transform.position = pos;

                    _jumpState = JumpState.NotJumping;
                }
                break;
        }
	}
}
