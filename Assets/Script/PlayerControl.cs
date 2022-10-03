using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement = new Vector2(0, 0);
    public static PlayerControl instance;
    public int speed = 0;
    private bool isBusy = false;
    private GameObject target = null;
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerMoveByButtom();
        InteractWithNPC();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                PlayerBackpack.instacne.AddToBackpack(other.gameObject);
                break;
            case "NPC":
                if (!isBusy)
                {
                    isBusy = true;
                    other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    Debug.Log("Hit " + other.gameObject.name);
                    target = other.gameObject;
                }
                break;
            default:
                Debug.Log("Unkown trigger");
                break;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                break;
            case "NPC":
                isBusy = false;
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log("Leave " + other.gameObject.name);
                target = null;

                break;
            default:
                Debug.Log("Unkown trigger");
                break;
        }
    }
    void InteractWithNPC()
    {
        if (Input.GetKeyDown(KeyCode.E) && target != null)
        {
            target.GetComponent<NPCControl>().InteractActivity();
        }
    }

}

