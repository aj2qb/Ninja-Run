using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : MonoBehaviour
{

    public Rigidbody2D waterEnemy;
    Vector3 waterEnemyPosition;
    float waterRandNumber;
    float waterRandSpawn;
    public GameObject waterNinja;

    public bool waterEnemyTrue = false;

    public GameObject waterCloudParticlePrefab;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Earth Throw")
        {
            GameObject poof = Instantiate(waterCloudParticlePrefab, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(poof, 2);

        }

        if (!waterNinja.GetComponent<NinjaController>().gameOver)
        {
            waterNinja.GetComponent<NinjaController>().score += 100; // Enemy Destroy Bonus
        }

        if (collision.gameObject.tag == "Ninja")
        {
            waterNinja.GetComponent<NinjaController>().gameOver = true;

        }

        if (collision.gameObject.tag == "Air Enemy" || collision.gameObject.tag == "Earth Enemy" || collision.gameObject.tag == "Fire Enemy")
        {
            this.gameObject.transform.position = new Vector3(18, -2f);
        }
    }

    void createEnemy()
    {
        if (waterEnemyTrue)
        {
            Rigidbody2D earthEnemy1 = Instantiate(waterEnemy, waterEnemyPosition, Quaternion.identity);
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
        if (randNumber < 2)
        {
            waterEnemyTrue = true;
        }
        else
        {
            waterEnemyTrue = false;
        }

        print(waterEnemyTrue);

    }

    void Start()
    {
        waterEnemyPosition = new Vector3(6f, -3.84f, 0);
        waterRandSpawn = Random.Range(2, 5);
        InvokeRepeating("createEnemy", waterRandSpawn, 7);
        InvokeRepeating("setEnemiesTrue", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        waterRandNumber = Random.Range(0, 4);
        waterRandSpawn = Random.Range(2, 5);
        if (waterRandNumber <= 1)
        {
            waterEnemyPosition.y = -3.5f;

        }
        else if (1 < waterRandNumber && waterRandNumber <= 2)
        {
            waterEnemyPosition.y = -2f;

        }
        else if (2 < waterRandNumber && waterRandNumber <= 4)
        {
            waterEnemyPosition.y = -2.5f;

        }
    }
}
