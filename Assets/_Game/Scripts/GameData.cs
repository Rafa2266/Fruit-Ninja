using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavedScore(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("highscore");
    }
    public void SavedSounds(int value)
    {
        PlayerPrefs.SetInt("sounds", value);
    }
    public int GetSounds()
    {
        return PlayerPrefs.GetInt("sounds")!=0? PlayerPrefs.GetInt("sounds"):2;
    }
}
