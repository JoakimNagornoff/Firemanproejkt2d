using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int startLives = 3;
    int points = 0;

    public TextMeshPro scoreText;
    public LivesController livesController;
    JumperSpawner jumperSpawner;

    private void OnEnable()
    {
      
        JumperController.OnJumperCrashed += JumperCrashed;
        JumperController.OnJumperSaved += JumperSaved;
    }
    private void OnDisable()
    {
        JumperController.OnJumperCrash -= JumperCrashed;
        JumperController.OnJumperSaved -= JumperSaved;
    }
    private void Start()
    {
        UpdateScoreLabel();
        livesController.InitLives(startLives);
        jumperSpawner = GetComponent<JumperSpawner>();


    }
    public void JumperCrashed()
    {

        Debug.Log("GM die");
        if(!livesController.RemoveLife())
        {
            Debug.Log("Game Over");

            jumperSpawner.Stop();
        }
      
    }
    public void JumperSaved()
    {
        points++;
        UpdateScoreLabel();

    }
   void UpdateScoreLabel()
    {
        scoreText.text = points.ToString();
    }
}
