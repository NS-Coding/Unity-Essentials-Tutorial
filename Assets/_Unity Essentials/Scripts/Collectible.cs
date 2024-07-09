using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float rotationX = 1f;
    public float rotationY = 1f;
    public float rotationZ = 1f;


    private Vector3 startPosition;

    public GameObject onCollectEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Bob up and down
        float y = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(startPosition.x, y, startPosition.z);
    
        // Rotation
        transform.Rotate(rotationX, rotationY, rotationZ);
    
    }


    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player")) {
            
         // Destroy the Collectible
        Destroy(gameObject);

        // instantiate the particle effect
        Instantiate(onCollectEffect, transform.position, transform.rotation);

        }


    }


}
