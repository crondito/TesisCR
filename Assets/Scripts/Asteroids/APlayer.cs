using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class APlayer : MonoBehaviour
{
    [SerializeField]
    int scene;

    public float acceleration;
    public float maxSpeed;
    public float drag;
    public float angularSpeed;
    public float offsetBullet;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public float shootRate = 0.5f;

    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;
    private bool shooting;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    private void Update()
    {
        vertical = AInputManager.Vertical;
        horizontal = AInputManager.Horizontal;
        shooting = AInputManager.Fire;

        Rotate();
        Shoot();
    }

    private void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp(vertical, 0f, 1f);
        rb.AddForce(transform.up * acceleration * forwardMotor);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate()
    {
        if(horizontal == 0)
        {
            return;
        }
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }

    private void Shoot()
    {
        if (shooting && canShoot)
        {
            FindObjectOfType<SoundManagerScript>().Play("Laser");
            StartCoroutine(FireRate());
        }
    }

    public void Lose()
    {
        // rb.velocity = Vector3.zero;
        // transform.position = Vector3.zero;
        SceneManager.LoadScene(scene);
    }

    private IEnumerator FireRate()
    {
        canShoot = false;
        var pos = transform.up * offsetBullet + transform.position;
        var bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Destroy(bullet, 2);
        yield return new WaitForSeconds(shootRate);
        canShoot = true;
    }
}
