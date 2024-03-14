using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out PlayerInputs Player))
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
