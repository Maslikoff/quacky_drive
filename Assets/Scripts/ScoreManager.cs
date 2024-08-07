using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _textScore;

    [Header("Settings")]
    [SerializeField] private int _scorePerSecond = 5;
    [SerializeField] private int _targetScore = 50;
    [SerializeField] private float _timer = 1;

    private int _currentScore = 0;
    private LevelManager _levelManager;

    private void Start()
    {
        StartCoroutine(AccumulateScore());
    }

    private IEnumerator AccumulateScore()
    {
        while (_currentScore < _targetScore)
        {
            _currentScore += _scorePerSecond;
            _textScore.text = _currentScore.ToString();
            Debug.Log($"Текущий счёт: {_currentScore}");
            yield return new WaitForSeconds(1); 
        }

        LoadVictoryScene();
    }

    private void LoadVictoryScene()
    {
        _levelManager.LoadVictoryScene();
    }
}
