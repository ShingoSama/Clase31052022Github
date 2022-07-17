using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed;
    public float speedSprint;
    public float groundDistance;
    public float jumpForce;
    Vector3 moveDirection;
    bool isGrounded;
    bool isRun;
    bool isSprint;
    [SerializeField]
    float speedTotal;
    float ver;
    float hor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIsGrounded();
        
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        animator.SetFloat("Strafe", hor);
        animator.SetFloat("Forward", ver);

        if (Input.GetButton("Fire3"))
        {

            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        
    }
    private void Jump()
    {
        
    }
    private void SpeedControl()
    {

    }
    private bool CheckIsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Interactable")
        {
            hit.collider.GetComponent<Interactable>().ShowMessage();
        }
    }
}