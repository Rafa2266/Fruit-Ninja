using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text txtScore, txtHighScore;
    public Image[] imagLifes;
    public Button btnpause, btnResume, btnBackMainMenu, btnClosePauseMenu, btnSounds;
    public GameObject panelGame, PanelPause, panelGameOver;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.SetActive(true);
        PanelPause.SetActive(false);
        gameController=FindObjectOfType<GameController>();
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
        for(int i=0; i<imagLifes.Length;i++)
        {
            imagLifes[i].color = gameController.uiWhiteColor;
        }
    }
}
