using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [ReadOnly]
    public int Score = 0;
    public TMP_Text ScoreText;

    void Awake()
    {
        Instance = this;
    }

    public static void AddScore(int points)
    {
        Instance.Score += points;
        Instance.ScoreText.text = Instance.Score.ToString();
    }

    public static void RemoveScore(int points)
    {
        Instance.Score -= points;
        Instance.ScoreText.text = Instance.Score.ToString();
    }
}
