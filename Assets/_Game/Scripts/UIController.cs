using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    public TMP_Text txtScore,txtScoreGameOver;
    [SerializeField] private TMP_Text[] txtHighScores;
    public Image[] imagLifes;
    public Button btnpause, btnResume, btnBackMainMenu, btnClosePauseMenu, btnSounds,btnSoundsMainMenu;
    public GameObject panelGame, PanelPause, panelGameOver, panelMainMenu;
    private GameController gameController;
    private AudioController audioController;
    public Sprite soundOn,soundOff;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.SetActive(false);
        panelMainMenu.SetActive(true);
        panelGameOver.SetActive(false);
        PanelPause.SetActive(false);
        gameController=FindObjectOfType<GameController>();
        audioController=FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ButtonPauseGame()
    {
        panelGame.SetActive(false);
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonClosePanelPause()
    {
        panelGame.SetActive(true);
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void ShowPanelGameOver()
    {
        panelGameOver.SetActive(true);
        panelGame.SetActive(false);
        gameController.GameOver();
    }
    public IEnumerator ShowBombPanelGameOver()
    {
        gameController.GameOver();
        panelGame.SetActive(false);
        yield return new WaitForSeconds(2f);
        panelGameOver.SetActive(true);
    }
    public void ButtonRestartGame()
    {
        panelGameOver.SetActive(false);
        panelGame.SetActive(true);
        gameController.RestartGame();
        txtScore.text = "Score: " + gameController.score.ToString();
        for (int i=0; i<imagLifes.Length;i++)
        {
            imagLifes[i].color = gameController.uiWhiteColor;
        }
    }
    public void ChangeHighScoreText(int score)
    {
        foreach(TMP_Text txtHighScore in txtHighScores)
        {
            txtHighScore.text = "Highscore: " + score;
        }
    }
    public void ButtonSounds()
    {
        if(gameController.soundOnOff)
        {
            gameController.soundOnOff = false;
            btnSounds.GetComponent<Image>().sprite = soundOff;
            btnSoundsMainMenu.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            gameController.soundOnOff = true;
            btnSounds.GetComponent<Image>().sprite = soundOn;
            btnSoundsMainMenu.GetComponent<Image>().sprite = soundOn;
        }
        audioController.EnableAndDisableAudio(gameController.soundOnOff,gameController.allObjects);
        gameController.SoundsData();
    }
    public void ChangeSounds(bool soundOnOff)
    {
        if (!soundOnOff)
        {
            btnSounds.GetComponent<Image>().sprite = soundOff;
            btnSoundsMainMenu.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            btnSounds.GetComponent<Image>().sprite = soundOn;
            btnSoundsMainMenu.GetComponent<Image>().sprite = soundOn;
        }
        
    }

    public void ButtonBackMainMenu()
    {
        panelGame.SetActive(false);
        panelMainMenu.SetActive(true);
        panelGameOver.SetActive(false);
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
        gameController.BackMainMenu();
        for (int i = 0; i < imagLifes.Length; i++)
        {
            imagLifes[i].color = gameController.uiWhiteColor;
        }
    }

    public void ButttonStartGame()
    {
        panelGame.SetActive(true);
        panelMainMenu.SetActive(false);
        gameController.StartGame();
        txtScore.text = "Score: " + gameController.score.ToString();

    }
}
