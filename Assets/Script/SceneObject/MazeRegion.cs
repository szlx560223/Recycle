using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRegion : MonoBehaviour
{
    private Vector3 finalPos = new Vector3(0,0,-1);
    private Vector3 currentPos = new Vector3(0, 0, 0);

    public float moveSpeed = 5f;
    private Transform cam;
    private float currentZ; 

    void OnTriggerEnter2D(Collider2D other)
    {
        finalPos.z = -4;
        if (other.CompareTag("Player")){
            cam = other.transform.GetChild(0);
        }
            
            
    }
    void OnTriggerExit2D(Collider2D other)
    {
        finalPos.z = -1;
        if (other.CompareTag("Player"))
        {
            cam = other.transform.GetChild(0);
        }
    }
    void Start()
    {
        currentZ = finalPos.z;
    }
    void Update()
    {
        Debug.Log(currentZ);
        if(cam != null)
        {
            currentZ = Mathf.MoveTowards(currentZ, finalPos.z, Time.deltaTime * moveSpeed);
            currentPos.z = currentZ;
            cam.localPosition = currentPos;
        }
        
    }
}
