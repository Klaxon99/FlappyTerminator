using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartGameScreen _startGameScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void Start()
    {
        Time.timeScale = 0f;
        _startGameScreen.Open();
    }

    private void OnEnable()
    {
        _startGameScreen.PlayButtonClicked += OnPlayerButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _startGameScreen.PlayButtonClicked -= OnPlayerButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayerButtonClick()
    {
        _startGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _player.ResetStats();
        _enemyGenerator.Reset();
    }
}