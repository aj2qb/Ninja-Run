using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{

    public Rigidbody2D fireEnemy;
    Vector3 fireEnemyPosition;
    float fireRandNumber;
    float fireRandSpawn;
    public GameObject fireNinja;

    public bool fireEnemyTrue = false;

    public GameObject fireCloudParticlePrefab;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water Throw")
        {
            GameObject poof = Instantiate(fireCloudParticlePrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(poof, 2);

        }

        if (!fireNinja.GetComponent<NinjaController>().gameOver)
        {
            fireNinja.GetComponent<NinjaController>().score += 100; // Enemy Destroy Bonus
        }

        if (collision.gameObject.tag == "Ninja")
        {
            fireNinja.GetComponent<NinjaController>().gameOver = true;

        }

        if (collision.gameObject.tag == "Water Enemy" || collision.gameObject.tag == "Earth Enemy" || collision.gameObject.tag == "Air Enemy")
        {
            this.gameObject.transform.position += new Vector3(8, 0);
        }
    }

    void createEnemy()
    {
        if (fireEnemyTrue)
        {
            Rigidbody2D earthEnemy1 = Instantiate(fireEnemy, fireEnemyPosition, Quaternion.identity);
            earthEnemy1.velocity = new Vector2(-5, 0);
            if (earthEnemy1.gameObject != null)
            {
                Destroy(earthEnemy1.gameObject, 5);
            }
           

        }


    }


    void setEnemiesTrue()
    {
        float randNumber = Random.Range(0, 5);
        if (randNumber < 2)
        {
            fireEnemyTrue = true;
        }
        else
        {
            fireEnemyTrue = false;
        }

        print(fireEnemyTrue);

    }

    void Start()
    {
        //ninja.AddComponent<NinjaController>();         
        fireEnemyPosition = new Vector3(6f, -3.84f, 0);
        fireRandSpawn = Random.Range(2, 5);
        InvokeRepeating("createEnemy", fireRandSpawn, 8);
        InvokeRepeating("setEnemiesTrue", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        fireRandNumber = Random.Range(0, 4);
        fireRandSpawn = Random.Range(2, 5);
        if (fireRandNumber <= 1)
        {
            fireEnemyPosition.y = -3.5f;

        }
        else if (1 < fireRandNumber && fireRandNumber <= 2)
        {
            fireEnemyPosition.y = -2f;

        }
        else if (2 < fireRandNumber && fireRandNumber <= 4)
        {
            fireEnemyPosition.y = -2.5f;

        }
    }
}
