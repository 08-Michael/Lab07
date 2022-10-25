using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))           
        {
            transform.position += transform.up;
            thisAnimation.Play();
        }

        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }       
    }
}
