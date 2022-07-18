using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject HandArrow;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed;
    public float speedSprint;
    public float groundDistance;
    public float jumpForce;
    public float gravity;
    public Vector3 velocity;
    Vector3 moveDirection;
    bool isGrounded;
    bool isRun;
    bool isSprint;
    bool isAiming;
    [SerializeField]
    float speedTotal;
    float ver;
    float hor;

    [Header("Camera & character Syncing")]
    public float lookDistance = 5;
    public float lookSpeed = 5;

    [Header("Aiming Settings")]
    RaycastHit hit;
    public LayerMask aimLayer;
    Ray ray;

    [Header("Spine Settings")]
    public Transform spine;
    public Vector3 spineOffSet;

    [Header("Head Rotation Settings")]
    public float lookAtPoint = 2.8f;

    Transform mainCam;

    public Bow bow;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        HandArrow.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIsGrounded();
        animator.SetBool("Ground", isGrounded);
        isAiming = Input.GetButton("Fire2");

        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        animator.SetFloat("Strafe", hor);
        animator.SetFloat("Forward", ver);

        CharacterAim(isAiming);
        
        if (isAiming)
        {
            HandArrow.gameObject.SetActive(true);
            CharacterPullString(isAiming);
            if (Input.GetButtonDown("Fire1"))
            {
                CharacterFireArrow();
            }
        }
        else
        {
            HandArrow.gameObject.SetActive(false);
        }
        if (Input.GetButton("Fire3"))
        {
            Aim();
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            animator.SetTrigger("Jump");
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    private void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        if (isAiming)
        {
            //RotateCharacterSpine();
        }
    }
    private void HandArrowActive()
    {
        HandArrow.gameObject.SetActive(true);
    }
    public void CharacterAim(bool aiming)
    {
        animator.SetBool("Aim", aiming);
    }
    public void CharacterPullString(bool pullString)
    {
        animator.SetBool("PullString", pullString);
    }
    public void CharacterFireArrow()
    {
        animator.SetTrigger("Fire");
    }
    void Aim()
    {
        Vector3 camposition = mainCam.position;
        Vector3 dir = mainCam.forward;
        ray = new Ray(camposition, dir);
        if (Physics.Raycast(ray, out hit, 500f, aimLayer))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            //bow.ShowCrossHair(hit.point);
        }
        else
        {
            bow.RemoveCrossHair();
        }
    }
    void RotateCharacterSpine()
    {
        spine.LookAt(ray.GetPoint(50));
        spine.Rotate(spineOffSet);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * 10);
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