using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        MovementInput();
        RotatePlayer();
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;

    private float fireTimer;

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    void RotatePlayer()
    {
        float angle = Utility.AngleTowardsMouse(transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;

        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
            fireTimer -= Time.deltaTime;
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bullet.GetComponent<Bullets>().speed;
    }
}
