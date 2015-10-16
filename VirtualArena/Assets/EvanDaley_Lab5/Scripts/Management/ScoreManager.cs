using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    private int score = 0;

	void Start () {
        // check if we already have a score manager
        if (Instance != null)
            print("Created score manager twice. This could cause errors.");

        // set the global reference to this object
        Instance = this;

        // get the score from the playerprefs
        //AddScore(PlayerPrefs.GetInt("score", 0));
        AddScore(0);
	}
	
	void SaveScore()
    {
        // save the score to playerprefs
        PlayerPrefs.SetInt("score", score);
    }

    public void AddScore(int num)
    {
        score += num;

       // if(DrawScore.Instance != null)
       //     if(DrawScore.Instance.Text != null)
                DrawScore.Instance.Text = score.ToString();
    }

    void OnApplicationQuit()
    {
        SaveScore();
    }
}
