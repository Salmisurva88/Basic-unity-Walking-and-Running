using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 700f; // Kecepatan rotasi pemain

    public Camera mainCamera;
    public float mouseSensitifity = 200;

    private Animator animator;
    public CharacterController characterController;
    private Rigidbody rb;

    bool isRunning;
    bool isWalking;

    float speedrunning = 5f;
    float speedwalking = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
        LookAround();
        //rotasi();
    }
    private void Move()
    {
        isWalking = Input.GetAxis("Jalan") > 0f;
        animator.SetBool("isWalking", isWalking);

        isRunning = Input.GetAxis("Lari") > 0f;
        animator.SetBool("isRunning", isRunning);
        speed = isRunning ? speedrunning : speedwalking;

        
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        /*if (Mathf.Abs(moveX)>0.1f || Mathf.Abs(moveY) >0.1f)
        {
            float sudutInput = Mathf.Atan2(moveX, moveY) * 180 / 3.14f;
            float sudutKamera = Camera.main.transform.eulerAngles.y;
            float sudutTarget = sudutInput + sudutCamera;
            
            trans
        }*/

        Vector3 direction = new Vector3(moveX, 0, moveY) * speed * Time.deltaTime;

        transform.Translate(direction);
    }

    private void LookAround()
    { 
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        float yRotation = moveX * mouseSensitifity * Time.deltaTime;
        float xRotation = -moveY * mouseSensitifity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -45, 45);

        transform.Rotate(Vector3.up, yRotation);
        mainCamera.transform.Rotate(Vector3.right, xRotation);
    }
    public void rotasi()
    {
        float horizontal = Input.GetAxis("Vertical"); // A/D atau panah kiri/kanan
        float vertical = Input.GetAxis("Horizontal"); // W/S atau panah atas/bawah

        // Balikkan nilai vertikal (W maju, S mundur)
        vertical = vertical > 0 ? -1 : (vertical < 0 ? 1 : 0); // Jika W ditekan, maju (1), jika S ditekan mundur (-1)

        // Gerakkan karakter
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            // Hitung rotasi berdasarkan input gerakan
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Pindahkan karakter ke arah yang dituju
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

            // Set parameter animasi untuk berjalan
            animator.SetBool("isWalking", true);
        }
        else
        {
            // Jika tidak ada input gerakan, karakter dalam keadaan diam
            animator.SetBool("isWalking", false);
        }

        // Mengirimkan input untuk animasi bergerak (opsional, jika diperlukan)
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }

}
