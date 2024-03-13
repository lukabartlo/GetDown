using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;

    public static PlayerInputs Instance;

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
        }
        else 
        { 
            Destroy(this); 
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_rigidbody.velocity.x > 0)
            {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

            }
            _rigidbody.AddForce(Vector2.left * _speed, ForceMode2D.Force);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (_rigidbody.velocity.x < 0)
            {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

            }
            _rigidbody.AddForce(Vector2.right * _speed, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded() == true) 
        {
            _rigidbody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, _boxSize, 0, -transform.up, _castDistance, _groundLayer))
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

  /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }*/
}
