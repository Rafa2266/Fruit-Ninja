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
    public GameObject panelGame, PanelPause;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.SetActive(true);
        PanelPause.SetActive(false);
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
}
