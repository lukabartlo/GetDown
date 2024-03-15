using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSpikyBall : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;

    private Vector3 _rotateRight = new Vector3(0, 0, -1);

    private void Update()
    {

        transform.rotation *= Quaternion.Euler(_rotateRight);
        transform.position += new Vector3(_enemySpeed * Time.deltaTime,0 ,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            _enemySpeed = -_enemySpeed;
        }
    }
}
