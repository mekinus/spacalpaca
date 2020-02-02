using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    private GameObject gameManager;
    private Manager gm;
    // Start is called before the first frame update
    void Start()
    {
        FindGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FindGameManager()
    {
        gameManager = GameObject.Find("Game Manager");
        if (gameManager != null)
            

        {
            gm = gameManager.GetComponent<Manager>();
           
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gm != null)
                gm.GetCrystal();
            Destroy(gameObject);
        }
    }
}
