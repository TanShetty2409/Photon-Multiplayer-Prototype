using UnityEngine;
using Photon.Pun;
using Unity.Cinemachine;

public class PlayerController : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rotationSpeed = 120f;

    private Vector3 movement;
    private float gravity = -9.81f;

    private Rigidbody rb;
    private SkinnedMeshRenderer playerRenderer;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        rb.freezeRotation = true;
        
        if (photonView.IsMine)
        {
            CinemachineCamera vCam = FindFirstObjectByType<CinemachineCamera>();
            if (vCam != null)
            {
                vCam.Target.TrackingTarget = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX != 0f)
        {
            transform.Rotate(Vector3.up, moveX * rotationSpeed * Time.deltaTime);
        }

        movement = transform.forward * moveZ;
        if (Mathf.Abs(moveZ) > 0.1f || Mathf.Abs(moveX) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Wave");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            photonView.RPC("ChangeColorRPC", RpcTarget.AllBuffered, r, g, b);
        }

    }

    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }

    [PunRPC]
    public void ChangeColorRPC(float r, float g, float b)
    {
        playerRenderer.material.color = new Color(r, g, b);
    }
}
