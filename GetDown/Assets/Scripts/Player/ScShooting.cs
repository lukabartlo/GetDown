using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _knockback;

    [SerializeField] private Rigidbody2D _rigidbodyBullet;
    [SerializeField] private Rigidbody2D _rigidbodyPlayer;

    [SerializeField] private Transform _spawnPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ScPlayerInputs.Instance.isGrounded() == false)
        {
            GameObject playerBullet = Instantiate(bullet, _spawnPos.position, Quaternion.identity);
            playerBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * _bulletSpeed, ForceMode2D.Force);
            _rigidbodyPlayer.velocity = new Vector2(_rigidbodyPlayer.velocity.x, _knockback);
            StartCoroutine(DestroyBullet(0.25f,playerBullet));
        }
    }

    IEnumerator DestroyBullet(float seconds, GameObject bullet)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(bullet);
    }
}
