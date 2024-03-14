using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _spawnPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInputs.Instance.isGrounded() == false)
        {
            GameObject playerBullet = Instantiate(bullet, _spawnPos.position, Quaternion.identity);
            playerBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * _bulletSpeed, ForceMode2D.Force);
        }
    }
}
