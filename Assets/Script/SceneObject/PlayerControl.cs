using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement = new Vector2(0, 0);
    public GameObject endMenu;
    public static PlayerControl instance;
    public int speed = 0;
    private bool isBusy = false;
    private GameObject target = null;
    public int itemCount = 3;
    private int _pickedGarbageCount;
    public int pickedGarbageCount
    {
        get
        {
            return _pickedGarbageCount;
        }
        set
        {
            _pickedGarbageCount = value;
            isGameEnd();
        }
    }
    
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pickedGarbageCount = 0;
    }
    void Update()
    {
        PlayerMoveByButtom();
        InteractWithObject();
    }
    /// <summary>
    /// 玩家360°移动，不顺滑，不建议使用
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
            movement*=speed;
            rb.velocity = movement;//获取输入，如果有输入就正常
        }
        else if(movement.sqrMagnitude > 0.01f)
        {
            movement = rb.velocity;
            movement *= 0.5f;//没有输入就让速度减小
            rb.velocity = movement;
        }
        else
        {
            movement = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
        TransferDataToAnimator(movement.x, movement.y, movement.sqrMagnitude);
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
        TransferDataToAnimator(movement.x,movement.y,movement.sqrMagnitude);

    }
/// <summary>
/// 传递数值给动画组件
/// </summary>
    void TransferDataToAnimator(float horizontal,float vertical,float speed)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                PlayerBackpack.instacne.AddToBackpack(other.gameObject);
                break;
            case "Bin":
            case "Aunt":
                if (!isBusy)
                {
                    isBusy = true;
                    other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    Debug.Log("Hit " + other.gameObject.name);
                    target = other.gameObject;
                }
                break;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                break;
            case "Bin":
            case "Aunt":
                isBusy = false;
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log("Leave " + other.gameObject.name);
                if (target == other.gameObject)
                    target = null;

                break;
        }
    }
    void InteractWithObject()
    {
        if (Input.GetKeyDown(KeyCode.E) && target != null)
        {
            switch (target.tag)
            {
                case "Aunt":
                    target.GetComponent<Aunt>().InteractActivity();
                    break;
                case "Bin":
                    target.GetComponent<RubbishBin>().InteractActivity();
                    break;
            }
        }
    }
    bool isGameEnd()
    {
        if (pickedGarbageCount == itemCount)
        {
            endMenu.SetActive(true);
            Time.timeScale = 0;
            return true;
        }
        
        return false;
    }

}

