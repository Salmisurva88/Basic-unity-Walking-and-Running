using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan pemain
    public float rotationSpeed = 700f; // Kecepatan rotasi pemain

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        // Mendapatkan komponen Animator dan Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ambil input gerakan horizontal dan vertikal (WASD atau panah)
        float horizontal = Input.GetAxis("Vertical"); // A/D atau panah kiri/kanan
        float vertical = Input.GetAxis("Horizontal"); // W/S atau panah atas/bawah

        // Balikkan nilai vertikal (W maju, S mundur)
        vertical = vertical > 0 ? 1 : (vertical < 0 ? -1 : 0); // Jika W ditekan, maju (1), jika S ditekan mundur (-1)

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
