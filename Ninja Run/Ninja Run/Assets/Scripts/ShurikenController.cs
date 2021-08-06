using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public GameObject largeShuriken;
    public GameObject smallShuriken; 
    public float spawnTime;
    private Vector3 shurikenPositionLarge;
    private Vector3 shurikenPositionSmall; 
    

    private float randShurikenY;
    

    private float smallOrLargeShuriken;


    void createShuriken()
    {
        if(smallOrLargeShuriken < 2)
        {
            GameObject myObject = Instantiate(largeShuriken, shurikenPositionLarge, Quaternion.identity);
            myObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
            Destroy(myObject, 5);
        } else
        {
            GameObject myObject1 = Instantiate(smallShuriken, shurikenPositionSmall, Quaternion.identity);
            myObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
            Destroy(myObject1, 5);
        }
       
      
    }

    // Start is called before the first frame update
    void Start()
    {
        shurikenPositionLarge.x = Random.Range(6, 8);
       // shurikenPositionLarge.y = Random.Range(-3.9f, 0);
        shurikenPositionLarge.z = Random.Range(0, 1);

        shurikenPositionSmall.x = Random.Range(6, 8);
        //shurikenPositionSmall.y = Random.Range(-4, 0);
        shurikenPositionSmall.z = Random.Range(0, 1);

        randShurikenY = Random.Range(0,3);
        

        if(randShurikenY <= 1)
        {
            shurikenPositionLarge.y = -3.89f;
            shurikenPositionSmall.y = -4.07f; 
            
        } else if(1 < randShurikenY && randShurikenY <= 2)
        {
            shurikenPositionLarge.y = -3.7f;
            shurikenPositionSmall.y = -3.77f; 
        } else if(2 < randShurikenY && randShurikenY <= 3)
        {
            shurikenPositionLarge.y = -3.33f;
            shurikenPositionSmall.y = -3.75f; 
        }



        smallOrLargeShuriken = Random.Range(1, 3);
        spawnTime = Random.Range(3, 5);

        InvokeRepeating("createShuriken", 1, spawnTime); 

    }

    // Update is called once per frame
    void Update()
    {
        shurikenPositionLarge.x = Random.Range(6, 8);
        //shurikenPositionLarge.y = Random.Range(-3.5f, -2.5f);
        shurikenPositionLarge.z = Random.Range(0, 1);

        shurikenPositionSmall.x = Random.Range(6, 8);
        //shurikenPositionSmall.y = Random.Range(-4, 1);
        shurikenPositionSmall.z = Random.Range(0, 1);


        randShurikenY = Random.Range(0, 3);


        if (randShurikenY <= 1)
        {
            shurikenPositionLarge.y = -3.89f;
            shurikenPositionSmall.y = -4.07f;

        }
        else if (1 < randShurikenY && randShurikenY <= 2)
        {
            shurikenPositionLarge.y = -3.7f;
            shurikenPositionSmall.y = -3.77f;
        }
        else if (2 < randShurikenY && randShurikenY <= 2)
        {
            shurikenPositionLarge.y = -3.33f;
            shurikenPositionSmall.y = -3.75f;
        }


        spawnTime = Random.Range(5, 15);
        smallOrLargeShuriken = Random.Range(1, 3);
       
    }
}
