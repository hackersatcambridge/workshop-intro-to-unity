using UnityEngine;

/// <summary>
/// Spawns good and bad pickups, and also highjacked to place cubes at background
/// </summary>
public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] float _aheadMin = 20f;
    [SerializeField] float _aheadMax = 100f;
    [SerializeField] Obstacle _obstaclePrefab;
    [SerializeField] float _spawnProb = 0.03f;
    [SerializeField] float _minZ = 0f;
    [SerializeField] float _maxZ = 0f;

    void Update ()
    {
        if (GameLogic.Instance.State != GameLogic.GameState.Running)
        {
            return;
        }

        // spawn with low (time independent) probability
        if (Random.value < _spawnProb * Time.deltaTime * 60f)
        {
            // instantiate prefab
            var inst = Instantiate(_obstaclePrefab);
            inst.transform.position = new Vector3(
                GameLogic.Instance._player.transform.position.x + Random.Range(_aheadMin, _aheadMax),
                // pickups tend to congregate along top/bottom edge to stop player sliding along them
                Mathf.Clamp(Random.Range(-1f, 11f), 1f, 9f), 
                Random.Range(_minZ, _maxZ));

            // move pickup to center with 20% probablilty to stop player holding space and gliding down the middle (hard but possible)
            if(inst._penalty > 0f && Random.value < 0.2f)
            {
                var pos = inst.transform.position;
                pos.y = 5f;
                inst.transform.position = pos;
            }
        }
	}
}
