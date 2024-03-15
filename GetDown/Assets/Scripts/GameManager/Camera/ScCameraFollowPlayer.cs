using UnityEngine;

public class ScCameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    private void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _player.transform.position.y - 2.0f, _camera.transform.position.z);
    }
}
