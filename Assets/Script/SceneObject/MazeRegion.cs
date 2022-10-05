using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRegion : MonoBehaviour
{
    private Vector3 finalPos = new Vector3(0,0,-1);
    private Vector3 currentPos = new Vector3(0, 0, 0);

    public float moveSpeed = 5f;//移动位置
    private Transform cam;//相机节点
    private float currentZ; //与屏幕的距离

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
        if(cam != null)
        {
            //平滑插值
            currentZ = Mathf.MoveTowards(currentZ, finalPos.z, Time.deltaTime * moveSpeed);
            currentPos.z = currentZ;
            cam.localPosition = currentPos;
        }
        
    }
}
