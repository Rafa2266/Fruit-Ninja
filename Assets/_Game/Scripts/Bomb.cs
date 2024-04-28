using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed,startForce;
    [SerializeField] private GameObject lightBeam;
    private Rigidbody2D myRb;
    private float sentidoRotation;
    private AudioController audioController;
    void Start()
    {
        myRb = this.gameObject.GetComponent<Rigidbody2D>();
        ApplyForce();
        sentidoRotation = Random.Range(-1f, 1f);
        audioController = FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float speedRotation = Random.Range(speed,speed*2);
        speedRotation *= sentidoRotation;
        transform.Rotate(new Vector3(speedRotation,speedRotation,0f)*Time.deltaTime);
    }
    private void ApplyForce()
    {

        myRb.AddForce(transform.up * Random.Range(startForce - 6, startForce), ForceMode2D.Impulse);

    }
    public void BombGameOver()
    {
        speed= 0f;
        
        myRb.bodyType = RigidbodyType2D.Kinematic;
        myRb.simulated = false;
        CircleCollider2D myCollider=this.gameObject.GetComponent<CircleCollider2D>();
        myCollider.enabled= false;
        GameObject tempLightBeam= Instantiate(lightBeam,this.transform.position,Quaternion.identity) as GameObject;
        this.GetComponent<AudioSource>().clip = audioController.bombExplodeAudio;
        this.GetComponent<AudioSource>().Play();
        Destroy(tempLightBeam,8f);
    }
}
