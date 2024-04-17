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
    private float sentidoRotation;

    // Start is called before the first frame update
    void Start()
    {
        myRb= this.gameObject.GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        sentidoRotation= Random.Range(-1f, 1f);
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Random.Range(250f, 450f);
        speed *= sentidoRotation;
        myRb.transform.Rotate(new Vector3(0f, speed, speed) * Time.deltaTime);
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
