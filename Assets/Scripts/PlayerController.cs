using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI namespace
using UnityEngine.SceneManagement;//enable you to use scene management, this is used in restarting game
public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb; //remenber that all gamecomponents have their own files
    private float myTimer;//holds the count of time
    public Text timeText;//text that displays the count of time
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTimer = 30;
        SetTimer();
        winText.text = "";
    }

    void Update ()
    {
        myTimer -= Time.deltaTime;
        SetTimer();
    }
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") && myTimer > 0)
        {
            other.gameObject.SetActive(false);
            Time.timeScale = 0;//freezes the game
            winText.text = "you win!";
        }
    }

    void SetTimer ()
    {
        timeText.text = "Time Left: " + myTimer.ToString("f0");
        if (myTimer <= 0)
        {
            winText.text = "Time is Up!";
            myTimer = 0;
            Time.timeScale = 0;
            //SceneManager.LoadScene(0);//reload scene when the player is late
        }
    }

}