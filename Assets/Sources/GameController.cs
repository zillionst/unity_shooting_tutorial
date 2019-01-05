using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public float startWait = 1;
    public float spawnWait = 0.75f;
    public float waveWait = 2;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    int score;
    bool gameover;
    bool restart;

    void Start()
    {
        Screen.SetResolution(480, 800, false);
        gameover = false;
        restart = false;
        score = 0;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameover = true;
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true) {
            if (gameover == true)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }

            for (int i = 0; i < 10; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), 5, 16);

                Quaternion spawnRotaition = Quaternion.Euler(new Vector3(0, 180, 0));

                Instantiate(hazard, spawnPosition, spawnRotaition);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R) == true)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("shootingGameProject");
            }
        }
    }
}
