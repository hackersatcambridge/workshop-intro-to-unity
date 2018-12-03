using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles high level logic of game
/// </summary>
public class GameLogic : MonoBehaviour
{
    public Player _player;

    public static GameLogic Instance { get; private set; }

    float _startLevelTime;
    /// <summary>
    /// Time since level/gameplay started
    /// </summary>
    public float LevelTime { get { return Time.time - _startLevelTime; } }

    public AudioSource _runningMusic;
    public AudioSource _deathMusic;

    public Text _textTitle;
    public Text _textScore;

    public enum GameState
    {
        Running,
        Death,
    }
    GameState _gameState = GameState.Running;
    public GameState State { get { return _gameState; } }

    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    private void Start()
    {
        _startLevelTime = Time.time;
    }

    private void Update()
    {
        // hacky way to freeze LevelTime
        if (_gameState == GameState.Death)
        {
            _startLevelTime += Time.deltaTime;
        }

        // score
        _textScore.text = Mathf.Round(-1024f + LevelTime) + " :score";

        // title text
        if (_gameState == GameState.Running)
        {
            if (LevelTime < 2f)
            {
                _textTitle.enabled = Mathf.Repeat(LevelTime, 0.2f) < 0.1f;
            }
            else
            {
                _textTitle.enabled = false;
            }
        }

        // quit on escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // reload level on R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
        }
    }

    public void PlayerHitKillZone()
    {
        SetState(GameState.Death);
    }

    void SetState(GameState newState)
    {
        _gameState = newState;

        // change music if player just died
        if(newState == GameState.Death)
        {
            _runningMusic.Stop();
            _deathMusic.Play();
        }
    }
}
