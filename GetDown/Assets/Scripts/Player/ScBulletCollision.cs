using UnityEngine;

public class ScBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScSpikyBall SpikyBall) || collision.gameObject.layer == 9 || collision.TryGetComponent(out ScHeart Heart))
        {
            Destroy(gameObject);
        }

        else if (!collision.TryGetComponent(out ScPlayerInputs Player) && !collision.TryGetComponent(out ScBulletCollision Bullet))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } 
    }
}
