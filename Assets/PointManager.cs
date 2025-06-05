using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PointManager : MonoBehaviour
{
    public int scoreCount;
    public TextMeshProUGUI scoreText;
    private MainMenu menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        menu = new MainMenu(); 
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
        if (scoreCount >= 8)
            menu.Win();
        
    }
}
