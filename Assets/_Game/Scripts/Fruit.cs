using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRb;
    [SerializeField]private float startForce;
    public GameObject fruitSliced;
    private GameController gameController;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        myRb= this.gameObject.GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ApplyForce()
    {
        myRb.AddForce(transform.up * Random.Range(startForce-6,startForce), ForceMode2D.Impulse);
    }
    public Color32 ChangeSplashColor(GameObject GO)
    {
        string cloneObjectName=GO.transform.name;
        Color32 defaultColor= new Color32(255,255,255,255);
        switch(cloneObjectName)
        {
            case "Apple(Clone)":
                return gameController.appleColor;
            case "Coconut(Clone)":
                return gameController.coconutColor;
            case "Orange(Clone)":
                return gameController.orangeColor;
            case "Pineapple(Clone)":
                return gameController.pineappleColor;
            case "Pear(Clone)":
                return gameController.pearColor;
        }
        return defaultColor;
    }
}
