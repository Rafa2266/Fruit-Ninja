using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay, maxDelay,increaseDifficult;
    private float maxDelayTemp;
    private AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
        maxDelayTemp = maxDelay;
        StartCoroutine(Spawn());
    }
    public void Restart()
    {
        maxDelayTemp = maxDelay;
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelayTemp);
            yield return new WaitForSeconds(delay);
            if(maxDelayTemp>minDelay*5)
            {
                maxDelayTemp -= increaseDifficult;
            }
            
            int spawnIndex=Random.Range(0, spawnPoints.Length);
            Transform spawnPoint= spawnPoints[spawnIndex];

            GameObject fruitPrefab = Instantiate(fruitsPrefab[Random.Range(0, fruitsPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
            if (fruitPrefab.CompareTag("Bomb"))
            {
                spawnPoint.GetComponent<AudioSource>().clip = audioController.bombThrow;
            }
            else
            {
                spawnPoint.GetComponent<AudioSource>().clip = audioController.fruitThrow;
            }
            spawnPoint.GetComponent<AudioSource>().Play();

            Destroy(fruitPrefab,7f);
        }
    }

}
