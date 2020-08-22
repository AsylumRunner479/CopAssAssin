using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [Header("Speed Vars")]
    //value Variables
    public float moveSpeed, rotateSpeed;
    public float walkSpeed, runSpeed;
    public Rigidbody rigid;
    //Struct - Contains Multiple Variables (eg...3 floats)
    private Vector3 _moveDir;
    //Reference Variable
    public PlayerHandler player;
    public CharacterController _charC;
    public GameObject self;
    public Animator anim;

    private void Start()
    {
        _charC = GetComponent<CharacterController>();




    }

    private void Update()
    {
        
       
            Move();
    
        

    }

    private void Move()
    {
        if (!PlayerHandler.isDead)
        {
            //set speed
            
            

            


            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
            }
            else if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
            {
                if (Input.GetKeyDown("e"))
                {
                    moveSpeed = runSpeed;
                    anim.SetBool("Run", true);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Crouch", false);
                }
                else if (Input.GetKeyDown("q"))
                {
                    moveSpeed = 0;
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                    anim.SetBool("Crouch", true);
                }
                else
                {
                    moveSpeed = walkSpeed;
                    anim.SetBool("Walk", true);
                    anim.SetBool("Run", false);
                    anim.SetBool("Crouch", false);
                }
            }
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;
            rigid.AddForce(_moveDir);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, _moveDir, rotateSpeed, 0.0f);
            self.transform.rotation = Quaternion.LookRotation(newDirection);


        }
        if (PlayerHandler.isDead)
        {
            _moveDir = Vector3.zero;
        }




        _charC.Move(_moveDir * Time.deltaTime);
    }

}
