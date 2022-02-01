using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    private Move instance;//单例 

    private Rigidbody2D rb;
    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;
    private Animator anim;

    [Header("Mask")]
    public LayerMask Ground;
    public Collider2D coll;//指定碰撞盒 判断是否着陆

    [Header("Jump")]
    public Text jumpCountText;
    private int jumpCounts = 0;//跳跃个数

    [Header("Dash")]
    public float dashTime;//冲刺时间
    public float dashSpeed;//冲刺速度

    public Text DashCountText;
    private int DashCounts = 0;//冲刺个数

    private float lashDashTime;
    private float dashTimeLeft;//剩余冲锋时间

    private bool isDashing, isJumping;

    private Queue<GameObject> propQueue = new Queue<GameObject>();//创建Prop储存队列
    private static GameObject statusCurrentIndex;

    TaskQueue taskQueue = new TaskQueue();//创建全局任务
    Task actionMasterTask;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && DashCounts > 0)
        {
            CanDash();
        }
       
    }

    void FixedUpdate()
    {
       
        SwitchAnim();
        Movement();
        //若任务总量大于0
        if (taskQueue.m_TasksNum > 0) {
            if (jumpCounts > 0 && taskQueue._currentName == "Jump") {
                Jump();
            }

            if (DashCounts > 0 && taskQueue._currentName == "Dash") {
                Dash();
            }
            
        }
        Debug.Log("TaskProcess:" + taskQueue.TaskProcess);
        Debug.Log("MaxNum:" + taskQueue.m_TasksNum);
    }


    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PropInQueue(collision.gameObject);//毁前入队
        if (collision.tag == "Prop_Jump")
        {
            Destroy(collision.gameObject);
            jumpCounts++;
            jumpCountText.text = jumpCounts.ToString();
            taskQueue.OnStart = () => Debug.Log("OnStart"); 
            taskQueue.OnFinish = () => Debug.Log("OnFinish");
            taskQueue.AddTask(Jump,"Jump");//添加Jump任务
            taskQueue.Start();
            PlayerStatusManager.CurrentPlayerStatus = PlayerStatus.Jump;//改为跳跃状态
        }

        if (collision.tag == "Prop_Dash") {
            Destroy(collision.gameObject);
            DashCounts++;
            DashCountText.text = DashCounts.ToString();
            taskQueue.AddTask(Dash,"Dash");//添加Dash任务
            taskQueue.Start();
            PlayerStatusManager.CurrentPlayerStatus = PlayerStatus.Dash;//冲刺状态
        }

    }

    /// <summary>
    /// 移动逻辑（待优化）
    /// </summary>
    void Movement() {
        float horizontalMove = Input.GetAxis("Horizontal");
        
        //raw可以直接获得-1 0 1 三个数值而不是范围。
        float faceDir = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0) {
            rb.velocity = new Vector2(horizontalMove * moveSpeed * Time.deltaTime, rb.velocity.y);
            anim.SetFloat("isRun",Mathf.Abs(faceDir));
        }

        //转向设置
        if (faceDir != 0) {
            transform.localScale = new Vector3(faceDir,1,1);
        }
    }

    /// <summary>
    /// 冲刺逻辑
    /// </summary>
    void CanDash() {
        isDashing = true;
        dashTimeLeft = dashTime;

        lashDashTime = Time.time;
    }

    void Dash()
    {

        if (isDashing) {
            if (dashTimeLeft > 0) {
                rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, rb.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPoolCtl.instance.GetFromPool();
            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                //Debug.Log("yijingchongleDash()");
                //减少冲刺次数并返回
                DashCounts--;
                DashCountText.text = DashCounts.ToString();
                Debug.Log("DashDone");
            }
        }
    }

    /// <summary>
    /// 能力获取逻辑（待升级）
    /// </summary>
    void Jump() {
        //跳跃控制 && Jump.activeSelf
        if (Input.GetKeyDown(KeyCode.K) && coll.IsTouchingLayers(Ground)) {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce * Time.deltaTime);
            anim.SetBool("isJumping",true);
            
            jumpCounts--;
            jumpCountText.text = jumpCounts.ToString(); 
            Debug.Log("JumpDone");
        }
           
    }

    /// <summary>
    /// 变换动画及判断着陆
    /// </summary>
    void SwitchAnim() {
        anim.SetBool("isIdle",false);
        if (anim.GetBool("isJumping")) {
            if (rb.velocity.y < 0) {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }
        }
        else if (coll.IsTouchingLayers(Ground)) {
            anim.SetBool("isFalling",false);
            anim.SetBool("isIdle",true);
        }
       
    }

    /// <summary>
    /// prop入队
    /// </summary>
    public void PropInQueue(GameObject statusIndex) 
    {
        if (statusIndex.tag != "bg") {
            propQueue.Enqueue(statusIndex);
        } 
    }

    /// <summary>
    /// prop出队
    /// </summary>
    public void PropOutQueue()
    {
        statusCurrentIndex = propQueue.Dequeue();//当前队头
        Debug.Log(statusCurrentIndex);// ??null??
    }




}
