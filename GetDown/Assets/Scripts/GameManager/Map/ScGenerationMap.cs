using UnityEngine;

public class ScGenerationMap : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private int _spikyBallSpawnChance;
    [SerializeField] private int _heartSpawnChance;
    [SerializeField] private float _chanceSpawn;

    [SerializeField] private GameObject _destructibleBlock;
    [SerializeField] private GameObject _spikyBall;
    [SerializeField] private GameObject _heart;
    [SerializeField] private Transform _player;

    private int _seed;

    private void Start()
    {
        _seed = Random.Range(10000, -10000);
        GenerationMap();
    }

    private void GenerationMap()
    {
        for (int y = (int) _player.position.y - 2; y > - _height; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                if (Mathf.PerlinNoise(x / 10f + _seed, y / 10f + _seed) >= _chanceSpawn)
                {
                    Instantiate(_destructibleBlock, new Vector3(x, y), Quaternion.identity, gameObject.transform);
                }
                else if (Random.Range(0, _spikyBallSpawnChance) == 0)
                {
                    Instantiate(_spikyBall, new Vector3(x, y), Quaternion.identity);
                }
                else if (Random.Range(0, _heartSpawnChance) == 0)
                {
                    Instantiate(_heart, new Vector3(x, y), Quaternion.identity);
                }
            }
        } 
    }
}
