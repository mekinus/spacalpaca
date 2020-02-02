using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int type;
    private Player thePlayer;
    [SerializeField] private float lifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0f)
            SelfDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (type == 1)
                thePlayer.RecoverHP();
            else
                thePlayer.RecoverSP();
            Destroy(gameObject);
        }
    }

    void FindPlayer()

    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void SelfDestroy()

    {
        Destroy(gameObject);
    }

}
