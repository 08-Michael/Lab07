using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text ScoreText;
    public GameObject Obstacle;

    int ScoreCount = 0;

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

        if (Obstacle.transform.position.x <= -2)
        {
            ScoreCount++;

            ScoreText.GetComponent<Text>().text = "Score: " + ScoreCount;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }       
    }
}
