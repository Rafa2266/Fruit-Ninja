using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music, blade;
    public AudioClip[] bladeAudio, fruitSplashAudio;
    public AudioClip bombExplodeAudio,bombThrow,fruitThrow;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField]private float musicVolume, soundVolume;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAndDisableAudio(bool soundOnOff, Transform allObjects)
    {
        if(soundOnOff)
        {
            audioSources[0].volume = musicVolume;
            for(int i=1;i<audioSources.Length;i++)
            {
                audioSources[i].volume = soundVolume;
            }
            foreach (Transform child in allObjects)
            {
                child.GetComponent<AudioSource>().volume = soundVolume;
            }
        }
        else
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = 0f;
            }

            foreach(Transform child in allObjects)
            {
                child.GetComponent<AudioSource>().volume = 0f;
            }
        }
        
    }
}
