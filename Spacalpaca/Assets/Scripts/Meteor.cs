using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private Vector2 moveForce;
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private int type;
    [SerializeField] private int damageToTake;
    [SerializeField] private float lifeSpan;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotationAngle);

        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0f)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(moveForce);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
        }
    }


}
