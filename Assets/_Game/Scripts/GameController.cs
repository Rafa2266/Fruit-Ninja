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
    // Start is called before the first frame update
    void Start()
    {
        uIController=FindObjectOfType<UIController>();
        score=0;
        fruitCount=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        uIController.txtScore.text = "Score: " + score.ToString();
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
    }

    public void RestartGame()
    {
        score=0;
        uIController.txtScore.text = "Score: " + score.ToString();
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
}
