using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    public GameObject paddlePlayer;
    public GameObject paddleEnemy;


    public float ballSpeed = 30.0f;
    private float mapEdge = 8f;
 

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        paddlePlayer = GameObject.Find("Player");
        paddleEnemy = GameObject.Find("Enemy");
        ballRb.AddForce(Vector3.left * ballSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        BallDestryedOnEdges();
    }

    private void BallDestryedOnEdges()
    {
        if (transform.position.x > mapEdge || transform.position.x < -mapEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(paddlePlayer))
        {
            Debug.Log("Collision detected. Player.");
            ballRb.AddForce(Vector3.right * ballSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        
        if (collision.gameObject.Equals(paddleEnemy))
        {
            Debug.Log("Collision detected. Enemy.");
            ballRb.AddForce(Vector3.left * ballSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}


// Add different ball angle related to paddle position. 
