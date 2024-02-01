using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupPower : MonoBehaviour
{
    public bool isPowerUp;
    Renderer playerRenderer;
    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager=GameObject.Find("GameManager").GetComponent<ScoreManager>();
        playerRenderer=GameObject.Find("CH_Roadworker").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPowerUp)
        {
            StartCoroutine(enumerator());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            print("Power Up");
            isPowerUp=true;
            playerRenderer.material.color=Color.red;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") &&isPowerUp)
        {
            //bonus must be added
            scoreManager.score(true);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Obstacle") &&!isPowerUp)
        {
            scoreManager.livesXx();
            Destroy(collision.gameObject);
        }
        else
        {
            scoreManager.score(false);
        }
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(8);
        isPowerUp=false;
        playerRenderer.material.color=Color.white;
    }

}
