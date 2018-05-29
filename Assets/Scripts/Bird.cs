using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D birdBody2D;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        birdBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameControl.instance.setHighScore(PlayerPrefs.GetInt("Highscore"));
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // If left mouse button pressed
                birdBody2D.velocity = Vector2.zero;
                birdBody2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }

        }

    }

    void OnCollisionEnter2D ()
    {
        birdBody2D.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
