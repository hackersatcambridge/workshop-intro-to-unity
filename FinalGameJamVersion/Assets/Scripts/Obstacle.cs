using UnityEngine;

/// <summary>
/// A good or bad pickup
/// </summary>
public class Obstacle : MonoBehaviour
{
    public float _penalty = 1f;
    public ParticleSystem _hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            // each time we enter a pickup add positive or negative amount to accumulated penalty
            GameLogic.Instance._player._accumulatedPenalty += _penalty;

            var src = GetComponent<AudioSource>();
            src.Play();

            if (_hitEffect != null)
            {
                Instantiate(_hitEffect, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            // each time we exit a pickup remove positive or negative amount to accumulated penalty
            GameLogic.Instance._player._accumulatedPenalty -= _penalty;
        }
    }
}
