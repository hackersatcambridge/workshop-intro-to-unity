using UnityEngine;

/// <summary>
/// This is the yellow 'kill zone' that follows the player
/// </summary>
public class Fire : MonoBehaviour
{
	void Update()
    {
        // move forward at players speed
        var player = GameLogic.Instance._player;
        transform.position += Vector3.right * Time.deltaTime * player._speed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            // player hit, kill them
            GameLogic.Instance.PlayerHitKillZone();
        }
    }
}
