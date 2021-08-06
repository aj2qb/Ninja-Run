using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEnemy : MonoBehaviour
{

    public Rigidbody2D earthEnemy;
    Vector3 earthEnemyPosition;
    float earthRandNumber;
    float earthRandSpawn;
    public GameObject earthNinja; 

    public bool earthEnemyTrue = false; 

    public GameObject earthCloudParticlePrefab; 

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Air Throw")
        {
            GameObject poof = Instantiate(earthCloudParticlePrefab, this.gameObject.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(poof, 2);

            if (!earthNinja.GetComponent<NinjaController>().gameOver)
            {
                earthNinja.GetComponent<NinjaController>().score += 100; // Enemy Destroy Bonus
            }

        }

        if(collision.gameObject.tag == "Ninja")
        {
            earthNinja.GetComponent<NinjaController>().gameOver = true;
            
        }

        if (collision.gameObject.tag == "Water Enemy" || collision.gameObject.tag == "Air Enemy" || collision.gameObject.tag == "Fire Enemy")
        {
            this.gameObject.transform.position += new Vector3(7, 0);
        }
    }

    void createEnemy()
    {
        if (earthEnemyTrue) {
            Rigidbody2D earthEnemy1 = Instantiate(earthEnemy, earthEnemyPosition, Quaternion.identity);
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
        if(randNumber < 2)
        {
            earthEnemyTrue = true;
        } else
        {
            earthEnemyTrue = false; 
        }

        print(earthEnemyTrue); 
       
    }

    void Start()
    {
              
        earthEnemyPosition = new Vector3(6f, -3.84f, 0);
        earthRandSpawn = Random.Range(2, 5);
        InvokeRepeating("createEnemy", earthRandSpawn, 7);
        InvokeRepeating("setEnemiesTrue", 2, 4); 
    }

    // Update is called once per frame
    void Update()
    {
        earthRandNumber = Random.Range(0, 4);
        earthRandSpawn = Random.Range(2, 5);
        if (earthRandNumber <= 1)
        {
            earthEnemyPosition.y = -3.5f;

        }
        else if (1 < earthRandNumber && earthRandNumber <= 2)
        {
            earthEnemyPosition.y = -2f;

        }
        else if (2 < earthRandNumber && earthRandNumber <= 4)
        {
            earthEnemyPosition.y = -2.5f;

        }
    }
}
