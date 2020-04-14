using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    [Header("Speed Vars")]
    //value Variables
    public float moveSpeed, rotateSpeed;
    public float walkSpeed;
    public Rigidbody rigid;
    //Struct - Contains Multiple Variables (eg...3 floats)
    private Vector3 _moveDir;
    //Reference Variable
    public PlayerHandler player;
    public CharacterController _charC;
    public GameObject self;


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




            moveSpeed = walkSpeed;


            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {

            }
            else if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
            {

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
