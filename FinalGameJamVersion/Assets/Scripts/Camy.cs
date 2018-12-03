using UnityEngine;

/// <summary>
/// Camera script
/// </summary>
public class Camy : MonoBehaviour
{
    [SerializeField] Transform _subject;
    [SerializeField] Vector3 _offset = new Vector3(0f, 0f, -10f);
    [SerializeField] float _lookAhead = 10f;
    [SerializeField] float _lerpAmount = 0.1f;

	void LateUpdate()
    {
        if (GameLogic.Instance.State != GameLogic.GameState.Running)
        {
            return;
        }

        // interpolate towards target position
        var targetPos = _subject.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, _lerpAmount * 60f * Time.deltaTime);

        // lookahead down the track
        transform.LookAt(_subject.position + Vector3.right * _lookAhead);

        // roll the camera based on random value
        float rollValue = 30f * ProgressiveRandom.Value(0.9f, 0.1f);
        transform.rotation *= Quaternion.AngleAxis(rollValue, Vector3.forward);
	}
}
