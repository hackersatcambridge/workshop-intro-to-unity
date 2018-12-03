using UnityEngine;

public static class ProgressiveRandom
{
    /// <summary>
    /// Random value that escalates over time
    /// </summary>
    /// <param name="k">How much to ramp over time</param>
    /// <param name="freq">How fast random value changes</param>
    public static float Value(float k, float freq)
    {
        return (1f + k * GameLogic.Instance.LevelTime) * (Mathf.PerlinNoise(GameLogic.Instance.LevelTime * freq, 0.5f) - 0.5f);
    }
}
