using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject cameraWrap;
    public GameObject groundWrapping1;
    public GameObject groundWrapping2; 

    public float moveSpeed = 1;
    public float backgroundYPosition = 0; 

    // Camera height, width, and side edge positions
    float height;
    float width;
    float leftEdgePos;
    float rightEdgePos;


    private void FixedUpdate()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
       
        height = 2f * cameraWrap.GetComponent<Camera>().orthographicSize; 
        width = height * cameraWrap.GetComponent<Camera>().aspect; // width of the camera 

        leftEdgePos = cameraWrap.transform.position.x - (width / 2);
        rightEdgePos = cameraWrap.transform.position.x + (width / 2) - 0.1f;

        groundWrapping1.transform.position = new Vector3(leftEdgePos + width/2, backgroundYPosition, 0); // y and z positions are not accurate  
        groundWrapping2.transform.position = new Vector3(rightEdgePos + width/2, backgroundYPosition, 0); // y and z positions are not accurate  

    }

    // Update is called once per frame
    void Update()
    {
        leftEdgePos = cameraWrap.transform.position.x - (width / 2);
        rightEdgePos = cameraWrap.transform.position.x + (width / 2);

        if(groundWrapping1.transform.position.x + width/2 - 0.1f <= leftEdgePos)
        {
            groundWrapping1.transform.position = groundWrapping2.transform.position + (new Vector3(width - 0.1f, 0, 0)); 
        }

        if (groundWrapping2.transform.position.x + width / 2 <= leftEdgePos)
        {
            groundWrapping2.transform.position = groundWrapping1.transform.position + (new Vector3(width - 0.1f, 0, 0));
        }

        groundWrapping1.transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        groundWrapping2.transform.position += Vector3.left * Time.deltaTime * moveSpeed;


    }
}
