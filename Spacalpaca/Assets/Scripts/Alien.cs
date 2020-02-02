using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float moveSpeed;
    public int hp;
    private Player thePlayer;
    private float step;
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        step = moveSpeed * Time.deltaTime;
        HPHandler();
    }

    private void LateUpdate()
    {
        Chase();
    }


    void FindPlayer()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void TakeDamage()
    {
        hp--;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            thePlayer.TakeDamage();
            Destroy(gameObject);
        }
    }


    void HPHandler()
    {
        if (hp == 0)
            Destroy(gameObject);
    }

    void Chase()
    {
      if(thePlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, thePlayer.gameObject.transform.position, step);
        }
    }



}
