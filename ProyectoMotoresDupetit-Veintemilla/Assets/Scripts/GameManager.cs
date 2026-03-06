using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Player PlayerRef { get; private set; }

    public int score;

    [SerializeField] private Text _scoreText;


    private void Update()
    {
        Reset();
    }

    private void Awake()
    {
        Instance = this;
        PlayerRef = FindObjectOfType<Player>();


    }
    void Start()
    {
        
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.OnEnemyDied += OnEnemyDeath;
        }
    }

    public void OnEnemyDeath()
    {
        
        score += 100;
        _scoreText.text = "Score: " + score;

    }

    public void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
