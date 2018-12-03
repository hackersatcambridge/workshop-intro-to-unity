using UnityEngine;

/// <summary>
/// Black bars at side of screen which rotate over time
/// </summary>
public class Slice : MonoBehaviour {

    float _maxRot = -11f;

	void Update () {
        var ea = transform.localEulerAngles;
        ea.z = _maxRot * (2f * Mathf.PerlinNoise(GameLogic.Instance.LevelTime * 0.13f, 0.5f) - 1f) * (0.2f + 0.1f * GameLogic.Instance.LevelTime);
        transform.localEulerAngles = ea;
	}
}
