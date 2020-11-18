using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    float movespeed = 5.0f;
    
    public GameObject Scoretext;
    int score = 10;
    int Totalpowerupleft;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Totalpowerupleft = GameObject.FindGameObjectsWithTag("Powerup").Length;
        Debug.Log("Total Power Ups LEFT: " + Totalpowerupleft.ToString());
        if (Totalpowerupleft == 0)
        {
            Debug.Log("Going OVER to new Scene NOW when all power upsare taken! ");
            SceneManager.LoadScene("WinScene");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movespeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movespeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movespeed);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            score--;
            Scoretext.GetComponent<Text>().text = "Score:" + score.ToString();

            if(score == 0)
            {
                Debug.Log("Going OVER to new Scene NOW! ");
                SceneManager.LoadScene("EndScene");
            }
        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Powerup")
        {
            score++;
            Scoretext.GetComponent<Text>().text = "Score: " + score;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Going OVER to new Scene NOW! ");
            SceneManager.LoadScene("EndScene");
        }

        
    }


}
