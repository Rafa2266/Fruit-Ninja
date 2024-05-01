using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public GameObject splash;
    [HideInInspector]public Color32 appleColor=new Color32(252,242,198,255);
    [HideInInspector]public Color32 coconutColor = new Color32(215,213,212,255);
    [HideInInspector]public Color32 orangeColor = new Color32(215,119,36,255);
    [HideInInspector]public Color32 pineappleColor = new Color32(203,168,25,255);
    [HideInInspector]public Color32 pearColor = new Color32(245,233,174,255);
    [HideInInspector]public Color32 uiRedColor = new Color32(255,0,0,255);
    [HideInInspector]public Color32 uiWhiteColor = new Color32(255,255,255,255);

    [HideInInspector] public int score,fruitCount;

    [SerializeField] private GameObject fruitSpawner,blade,destroyer;

    private UIController uIController;
    private GameData gameData;
    private int highscore;

    public Transform allObjects, allSplashes, allSlicedFruits;
    [HideInInspector]public bool soundOnOff;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        uIController=FindObjectOfType<UIController>();
        gameData=FindObjectOfType<GameData>();
        audioController = FindObjectOfType<AudioController>();
        score =0;
        fruitCount=0;
        soundOnOff = true;
        Initialize();
        highscore=gameData.GetScore();
        uIController.ChangeHighScoreText(highscore);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Initialize()
    {
        int sounds =gameData.GetSounds();
        if(sounds==1)
        {
            soundOnOff = false;
            
        }
        else
        {
            soundOnOff= true;
        }
        uIController.ChangeSounds(soundOnOff);
        audioController.EnableAndDisableAudio(soundOnOff,allObjects);
    }

    public void StartGame()
    {
        score = 0;
        fruitCount = 0;
        fruitSpawner.SetActive(true);
        fruitSpawner.GetComponent<FruitSpawner>().Restart();
        blade.SetActive(true);
        destroyer.SetActive(true);
    }
    public void UpdateScore(int points)
    {
        score+=points;
        uIController.txtScore.text = "Score: " + score.ToString();
    }
    public void GameOver()
    {
        fruitSpawner.SetActive(false);
        blade.SetActive(false);
        destroyer.SetActive(false);
        uIController.txtScoreGameOver.text= "Score: " + score.ToString();
        if (score > highscore)
        {
            highscore=score;
            gameData.SavedScore(highscore);
            uIController.ChangeHighScoreText(highscore);
        }
    }

    public void RestartGame()
    {
        score=0;
        fruitCount =0;
        fruitSpawner.SetActive(true);
        GameObject[] clones,bombs;
        clones = GameObject.FindGameObjectsWithTag("Clone");
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
        foreach (GameObject bomb in bombs)
        {
            Destroy(bomb);
        }
        fruitSpawner.GetComponent<FruitSpawner>().Restart();
        blade.SetActive(true);
        destroyer.SetActive(true);
    }
    public void SoundsData()
    {
        if (soundOnOff)
        {
            gameData.SavedSounds(2);
        }
        else
        {
            gameData.SavedSounds(1);
        }
    }

    public void BackMainMenu()
    {
        score= 0;
        fruitCount=0;
        fruitSpawner.SetActive(false); 
        destroyer.SetActive(false);
        blade.SetActive(false);
        GameObject[] clones, bombs;
        clones = GameObject.FindGameObjectsWithTag("Clone");
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
        foreach (GameObject bomb in bombs)
        {
            Destroy(bomb);
        }
    }
}
