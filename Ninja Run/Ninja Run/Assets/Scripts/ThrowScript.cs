using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public GameObject ninja;
    
    public Rigidbody2D air;
    public Rigidbody2D water;
    public Rigidbody2D earth;
    public Rigidbody2D fire;

   
    Vector3 startPosition;


    public GameObject myCamera;
    public float cameraHeight;
    public float cameraWidth;

    void createThrow()
    {
        if (Input.GetKeyDown(KeyCode.A) && !ninja.GetComponent<NinjaController>().gameOver)
        {
            print("AIR");
            Rigidbody2D air1 = Instantiate(air, startPosition, Quaternion.identity);
            air1.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            ninja.GetComponent<NinjaController>().score -= 25; 
            if (air1 != null)
            {
                Destroy(air1.gameObject, 3.15f);
            }

        }
        if (Input.GetKeyDown(KeyCode.W) && !ninja.GetComponent<NinjaController>().gameOver)
        {
            print("WATER");
            Rigidbody2D water1 = Instantiate(water, startPosition, Quaternion.identity);
            water1.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            ninja.GetComponent<NinjaController>().score -= 25;
            if (water1 != null)
            {
                Destroy(water1.gameObject, 3.15f);
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !ninja.GetComponent<NinjaController>().gameOver)
        {
            print("EARTH");
            Rigidbody2D earth1 = Instantiate(earth, startPosition, Quaternion.identity);
            earth1.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            ninja.GetComponent<NinjaController>().score -= 25;
            if (earth1 != null)
            {
                Destroy(earth1.gameObject, 3.15f);

            }

        }
        if (Input.GetKeyDown(KeyCode.S) && !ninja.GetComponent<NinjaController>().gameOver)
        {
            print("FIRE");
            Rigidbody2D fire1 = Instantiate(fire, startPosition, Quaternion.identity);
            fire1.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            ninja.GetComponent<NinjaController>().score -= 25;

            if (fire1)
            {
                Destroy(fire1.gameObject, 3.15f);

            }

        }

    }

    // Start is called before the first frame update
    void Start()
        {
            cameraHeight = 2f * myCamera.GetComponent<Camera>().orthographicSize;
            cameraWidth = cameraHeight * myCamera.GetComponent<Camera>().aspect; // width of the camera 

             startPosition = new Vector3(ninja.transform.position.x, ninja.transform.position.y, 1f); 

        }

        // Update is called once per frame
        void Update()
        {
        startPosition = new Vector3(ninja.transform.position.x + 0.25f, ninja.transform.position.y, 1f);
        createThrow();

           
    }
    
}
