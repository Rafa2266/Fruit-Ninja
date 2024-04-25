using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollider : MonoBehaviour
{
    private Bomb bomb;
    private UIController uIController;

    private void Start()
    {
        bomb= this.gameObject.GetComponent<Bomb>();
        uIController = FindObjectOfType<UIController>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Blade"))
        {
            bomb.BombGameOver();
            StartCoroutine(uIController.ShowBombPanelGameOver());
        }
        if (target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
    }
}