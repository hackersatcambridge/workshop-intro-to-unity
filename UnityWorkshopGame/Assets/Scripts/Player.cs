using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0f, 60f)]
    public float _speed = 60f;

	void Update ()
    {
        transform.position += _speed * Vector3.forward * Time.deltaTime;
	}
}
