using UnityEngine;

public class ScPlayerInputs : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpHeight;

    public Rigidbody2D rigidbodyPlayer;

    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _endLayer;

    public static ScPlayerInputs Instance;

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
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (rigidbodyPlayer.velocity.x > 0)
            {
                rigidbodyPlayer.velocity = new Vector2(0, rigidbodyPlayer.velocity.y);
            }

            rigidbodyPlayer.AddForce(Vector2.left * _speed * Time.deltaTime, ForceMode2D.Force);

            if (_speed >= _maxSpeed) 
            {
                _speed = _maxSpeed;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (rigidbodyPlayer.velocity.x < 0)
            {
                rigidbodyPlayer.velocity = new Vector2(0, rigidbodyPlayer.velocity.y);
            }

            rigidbodyPlayer.AddForce(Vector2.right * _speed * Time.deltaTime, ForceMode2D.Force);

            if (_speed >= _maxSpeed)
            {
                _speed = _maxSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true) 
        {
            rigidbodyPlayer.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Force);
            ScAudioManager.Instance.PlaySong("Jump");
        }

        if (isGrounded() == true)
        {
            ScShooting.Instance.numberBullet = ScShooting.Instance.maxNumberBullet;
            ScEnergyBar.Instance.energyAmount.text = ScShooting.Instance.maxNumberBullet.ToString();
            ScEnergyBar.Instance.SetMaxEnergy();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            ScVictoryDefeat.Instance.Victory();
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }*/
}
