using UnityEngine;

/// <summary>
/// Sets background colour to random colours that escalate over time
/// </summary>
public class ColourMaster : MonoBehaviour
{
    [SerializeField] Camera _cam;

	void Update ()
    {
        _cam.backgroundColor = Color.HSVToRGB(
            Mathf.Repeat(0.5f + ProgressiveRandom.Value(0.5f, 0.2f), 1f),
            Mathf.Repeat(0.5f * ProgressiveRandom.Value(0.5f, 0.2f), 1f),
            Mathf.Min(1f, 0.1f + .03f * GameLogic.Instance.LevelTime));
    }
}
