using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement = new Vector2(0, 0);
    public static PlayerControl instance;
    public int speed = 0;
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerMoveByButtom();
    }
    /// <summary>
    /// 玩家360°移动
    /// </summary>
    void PlayerMoveByAxis()
    {
        //获取输入
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) movement.y = 0;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) movement.x = 0;
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();//输入归一化
        }
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            rb.velocity = movement * speed;//获取输入，如果有输入就正常
        }
        else if(movement.sqrMagnitude > 0.01f)
        {
            movement = rb.velocity;
            movement *= 0.5f;//没有输入就让速度减小
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    /// <summary>
    /// 玩家八个方向移动移动
    /// </summary>
    void PlayerMoveByButtom()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) movement.y++;
        if (Input.GetKey(KeyCode.S)) movement.y--;
        if (Input.GetKey(KeyCode.A)) movement.x--;
        if (Input.GetKey(KeyCode.D)) movement.x++;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) movement.y = 0;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) movement.x = 0;
        movement.Normalize();
        movement*=speed;
        rb.velocity = movement;


    }

}

