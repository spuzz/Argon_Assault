using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {


    
    [SerializeField] int scorePerSecond = 1;
    int score;
    Text scoreText;

    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

    }
	

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            score += scorePerSecond;
            scoreText.text = score.ToString();
            timer -= 1;
        }
	}
}
