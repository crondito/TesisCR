using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAsteroid1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject[] subAsteroids;
    public float numberOfAsteroids;

    //private bool isDestroying = false;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        ).normalized * speed;

        rb.angularVelocity = Random.Range(-50f, 50f);
    }

    void Start()
    {
        /*rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        ).normalized * speed;

        rb.angularVelocity = Random.Range(-50f, 50f);*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (isDestroying) return;

        if (col.CompareTag("Bullet"))
        {
            //isDestroying = true;
            FindObjectOfType<SoundManagerScript>().Play("Explotion");
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
            /*for (var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                    );
            }*/
        }

        if (col.CompareTag("Player"))
        {
            /*var asts = GameObject.FindGameObjectsWithTag("Asteroid");
            for (var i = 0; i < asts.Length; i++)
            {
                asts[i].gameObject.SetActive(false);
            }*/
            col.GetComponent<APlayer2>().Lose();
        }
    }
}
