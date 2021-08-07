using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Animator anim;
    public bool gameOver = false;
    public float score = 0;
    public LevelController levelControl; 

    void NinjaMove()
    {
        if (this.transform.position.y <= -3.89)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 6.5f);

            }
            if (GetComponent<Rigidbody2D>().velocity.y < 1f)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Shuriken")
        {
            gameOver = true;
            
        }
        if (collision.gameObject.tag == "Air Enemy")
        {
            gameOver = true;

        }
        if (collision.gameObject.tag == "Water Enemy")
        {
            gameOver = true;

        }
        if (collision.gameObject.tag == "Earth Enemy")
        {
            gameOver = true;

        }
        if (collision.gameObject.tag == "Fire Enemy")
        {
            gameOver = true;

        }


    }

   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        NinjaMove();
        if (!gameOver)
        {
            score += 0.25f;

        } else
        {
            print("Score: " + score);

        }

        levelControl.setGameStatus(gameOver);
        levelControl._finalScore = (int) score;
    }
}
