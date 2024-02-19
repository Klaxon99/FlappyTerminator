using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _scoreChangeTime;

    public event Action<int> ScoreChange;

    private int _score = 0;
    private float _timer;

    private void Update()
    {
        if (_timer >= _scoreChangeTime)
        {
            _timer = 0;
            Add();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    public void Add()
    {
        _score++;
        ScoreChange?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChange?.Invoke(_score);
    }
}