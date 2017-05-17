using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    public int points = 0;
    // Use this for initialization
    void Start () {
        scoreText.text = points + " point";
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = points + " point";
    }

    public void upgradeScore(int point)
    {
        this.points += point;
    }
}
