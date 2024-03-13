using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInputs.Instance.isGrounded() == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            _rigidbody.AddForce(Vector2.down * _bulletSpeed, ForceMode2D.Force);
        }

        /*OnTriggerEnter();*/
    }

    /*private void OnTriggerEnter2D(Collider other)
    {
        
    }*/
}
