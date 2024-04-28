using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;
    private UIController uiController;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        fruit= this.gameObject.GetComponent<Fruit>();
        gameController=FindObjectOfType<GameController>();
        uiController=FindObjectOfType<UIController>();
        audioController=FindObjectOfType<AudioController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Blade")){
            target.GetComponent<AudioSource>().clip = audioController.bladeAudio[Random.Range(0, audioController.bladeAudio.Length)];
            target.GetComponent<AudioSource>().Play();

            GameObject tempFruitSliced = Instantiate(fruit.fruitSliced,transform.position,Quaternion.identity);
            tempFruitSliced.GetComponent<AudioSource>().clip = audioController.fruitSplashAudio[Random.Range(0, audioController.fruitSplashAudio.Length)];
            tempFruitSliced.GetComponent<AudioSource>().Play();
            Vector3 positionSplash = tempFruitSliced.transform.position;
            positionSplash.z = 5;
            GameObject tempSplash = Instantiate(gameController.splash, positionSplash, Quaternion.identity);
            tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject);
            tempFruitSliced.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f,10f), ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f,10f), ForceMode.Impulse);
            gameController.UpdateScore(fruit.points);
            Destroy(tempFruitSliced, 5f);
            //Destroy(tempSplash, Random.Range(10f,20f));
            Destroy(this.gameObject);
        }
        if (target.gameObject.CompareTag("Destroyer")){
            gameController.fruitCount++;
            uiController.imagLifes[gameController.fruitCount - 1].color = gameController.uiRedColor;
            Destroy(this.gameObject);
            if (gameController.fruitCount >= 3)
            {
                uiController.ShowPanelGameOver();
            }
        }
    }
}
