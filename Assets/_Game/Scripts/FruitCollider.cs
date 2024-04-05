using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    // Start is called before the first frame update
    void Start()
    {
        fruit= this.gameObject.GetComponent<Fruit>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Blade")){
            GameObject tempFruitSliced = Instantiate(fruit.fruitSliced,transform.position,Quaternion.identity);
            tempFruitSliced.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f,10f), ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f,10f), ForceMode.Impulse);
            Destroy(tempFruitSliced, 5f);
            Destroy(this.gameObject);
        }
    }
}
