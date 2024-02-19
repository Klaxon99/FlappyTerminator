using UnityEngine;
using TMPro;

public class ScoreChangeHandler : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _score.ScoreChange += ChangeText;
    }

    private void OnDisable()
    {
        _score.ScoreChange -= ChangeText;
    }

    private void ChangeText(int score)
    {
        _text.text = score.ToString();
    }
}