using UnityEngine;

/// <summary>
/// Kill this gameobject some time after spawn
/// </summary>
public class TimedKill : MonoBehaviour
{
    [SerializeField] float _lifeTime = 10f;

	void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0f) Destroy(gameObject);
	}
}
