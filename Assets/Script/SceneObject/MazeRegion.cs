using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRegion : MonoBehaviour
{
    private Vector3 finalPos = new Vector3(0,0,-5);
    private Vector3 currentPos = new Vector3(0, 0, 0);
    public float moveSpeed = 5f;//移动位置
    private Transform cam;
    private float currentZ; //与屏幕的距离

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player")){
            finalPos.z = -10;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finalPos.z = -5;
        }
    }
    void Start()
    {
        cam = Camera.main.transform;//相机节点
        currentZ = finalPos.z;
    }
    void Update()
    {
        if(cam != null)
        {
            //平滑插值
            currentZ = Mathf.MoveTowards(currentZ, finalPos.z, Time.deltaTime * moveSpeed);
            currentPos.z = currentZ;
            cam.localPosition = currentPos;
        }
        
    }
}
