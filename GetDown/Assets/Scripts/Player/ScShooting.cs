using System.Collections;
using UnityEngine;

public class ScShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _knockback;

    [SerializeField] private Rigidbody2D _rigidbodyBullet;
    [SerializeField] private Rigidbody2D _rigidbodyPlayer;

    [SerializeField] private Transform _spawnPos;

    public int numberBullet;
    public int maxNumberBullet;

    public static ScShooting Instance;

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
        if (Input.GetKeyDown(KeyCode.Space) && ScPlayerInputs.Instance.isGrounded() == false && numberBullet > 0)
        {
            GameObject playerBullet = Instantiate(bullet, _spawnPos.position, Quaternion.identity);
            playerBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * _bulletSpeed, ForceMode2D.Force);
            _rigidbodyPlayer.velocity = new Vector2(_rigidbodyPlayer.velocity.x, _knockback);
            StartCoroutine(DestroyBullet(0.4f,playerBullet));
            numberBullet--;
            ScEnergyBar.Instance.SetEnergy(numberBullet);
            ScEnergyBar.Instance.energyAmount.text = numberBullet.ToString();
        }
    }

    IEnumerator DestroyBullet(float seconds, GameObject bullet)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(bullet);
    }
}
