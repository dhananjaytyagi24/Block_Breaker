using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointsPerBlockDestroyed;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
    {
        scoreText.text = currentScore.ToString();
        Debug.Log("In awake");
        Debug.Log("GameSession awake called");
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
            Debug.Log("current gameStatus object destroyed");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("DontDestroyOnLoad called");
        }
    }

    // Use this for initialization
    private void Start()
    {
        
        Debug.Log("GameSession start called");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        Debug.Log("score updated");
        Debug.Log("current score" + currentScore);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


}
