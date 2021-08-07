using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{

    public Rigidbody2D airEnemy;
    Vector3 airEnemyPosition;
    float airRandNumber;
    float airRandSpawn;
    public GameObject airNinja;

    public bool airEnemyTrue = false;

    public GameObject airCloudParticlePrefab;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire Throw")
        {
            GameObject poof = Instantiate(airCloudParticlePrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(poof, 2);

            if(!airNinja.GetComponent<NinjaController>().gameOver)
            {
                airNinja.GetComponent<NinjaController>().score += 100; // Enemy Destroy Bonus
            }

        }

        if (collision.gameObject.tag == "Ninja")
        {
            airNinja.GetComponent<NinjaController>().gameOver = true;

        }

        if(collision.gameObject.tag == "Water Enemy" || collision.gameObject.tag == "Earth Enemy" || collision.gameObject.tag == "Fire Enemy")
        {
            this.gameObject.transform.position = new Vector3(8, -3.5f); 
        }
    }

    void createEnemy()
    {
        if (airEnemyTrue)
        {
            Rigidbody2D earthEnemy1 = Instantiate(airEnemy, airEnemyPosition, Quaternion.identity);
            earthEnemy1.velocity = new Vector2(-5, 0);
            if (earthEnemy1.gameObject != null)
            {
                Destroy(earthEnemy1.gameObject, 6);
            }
           
        }


    }


    void setEnemiesTrue()
    {
        float randNumber = Random.Range(0, 5);
        if (randNumber < 3)
        {
            airEnemyTrue = true;
        }
        else
        {
            airEnemyTrue = false;
        }

        print(airEnemyTrue);

    }

    void Start()
    {
        airEnemyPosition = new Vector3(6f, -3.84f, 0);
        airRandSpawn = Random.Range(2, 5);
        InvokeRepeating("createEnemy", airRandSpawn, 7);
        InvokeRepeating("setEnemiesTrue", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        airRandNumber = Random.Range(0, 4);
        airRandSpawn = Random.Range(2, 5);
        if (airRandNumber <= 1)
        {
            airEnemyPosition.y = -3.5f;

        }
        else if (1 < airRandNumber && airRandNumber <= 2)
        {
            airEnemyPosition.y = -2f;

        }
        else if (2 < airRandNumber && airRandNumber <= 4)
        {
            airEnemyPosition.y = -2.5f;

        }
    }
}
