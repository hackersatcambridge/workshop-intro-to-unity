using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Ramps up post processing over time
/// </summary>
public class BrainMelter : MonoBehaviour
{
    PostProcessVolume _volume;

    void Start ()
    {
        _volume = GetComponent<PostProcessVolume>();
    }

    void Update ()
    {
        Bloom bloomLayer = null;
        if (_volume.profile.TryGetSettings(out bloomLayer))
        {
            bloomLayer.intensity.value = Mathf.Min(14f, 10f * Mathf.PerlinNoise(GameLogic.Instance.LevelTime * 0.2f, 0.5f) * (0.2f + 0.1f * GameLogic.Instance.LevelTime));
        }
        ChromaticAberration ca = null;
        if (_volume.profile.TryGetSettings(out ca))
        {
            ca.intensity.value = 1f * Mathf.PerlinNoise(GameLogic.Instance.LevelTime * 0.2f, 0.5f) * (0.2f + 0.1f * GameLogic.Instance.LevelTime);
        }
        LensDistortion ld = null;
        if (_volume.profile.TryGetSettings(out ld))
        {
            ld.intensity.value = Mathf.Clamp(100f * (-0.5f + Mathf.PerlinNoise(GameLogic.Instance.LevelTime * 0.2f, 0.5f) * (0.2f + 0.1f * GameLogic.Instance.LevelTime)), -60, 60);
        }

    }
}
