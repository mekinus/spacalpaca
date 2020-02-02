using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public enum PlayerState
    {
        powering,idle
    }

    public PlayerState playerState;
    public Image hpBar;
    public Image spBar;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Sprite[] lifeBar;
    [SerializeField] private Sprite[] powerBar;

    public int hp;
    public int sp;
    public Transform upBound;
    public Transform lowBound;
    public Transform rightBound;
    public Transform leftBound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
        CheckSP();
    }

    private void LateUpdate()
    {
        MovementHandler();
    }

    void MovementHandler()

    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(h * moveSpeed * Time.deltaTime, v * moveSpeed * Time.deltaTime);

        if (transform.position.x < leftBound.position.x)
            transform.position = new Vector3(leftBound.position.x, transform.position.y, 0f);
        else if (transform.position.x > rightBound.position.x)
            transform.position = new Vector3(rightBound.position.x, transform.position.y, 0f);
        else if (transform.position.y > upBound.position.y)
            transform.position = new Vector3(transform.position.x,upBound.position.y, transform.position.z);
        else if (transform.position.y < lowBound.position.y)
            transform.position = new Vector3(transform.position.x, lowBound.position.y, transform.position.z);

        if(Input.GetMouseButtonDown(0))
        {
            if(playerState == PlayerState.powering)
            UsePower();
        }
    }

    public void TakeDamage()
    {
        hp--;
    }

    public void UsePower()
    {
        if(sp > 0)
        {
            TakeSP();
            Debug.Log("THE POWER IS HERE !");
        }
      
    }

    public void RecoverHP()
    {
        if (hp < 3)
            hp++;
    }

    public void TakeSP()
    {
        sp--;
    }

    public void RecoverSP()
    {
        if (sp < 4)
            sp++;
    }



     void CheckHP()
    {
      switch(hp)
        {
            case 3: hpBar.overrideSprite = lifeBar[3]; break;
            case 2: hpBar.overrideSprite = lifeBar[2]; break;
            case 1: hpBar.overrideSprite = lifeBar[1]; break;
            case 0: hpBar.overrideSprite = lifeBar[0]; break;
            default: hpBar.overrideSprite = lifeBar[0]; break;
        }
    }

    void CheckSP()
    {
        switch (sp)
        {
            case 4: spBar.overrideSprite = powerBar[4]; break;
            case 3: spBar.overrideSprite = powerBar[3]; break;
            case 2: spBar.overrideSprite = powerBar[2]; break;
            case 1: spBar.overrideSprite = powerBar[1]; break;
            case 0: spBar.overrideSprite = powerBar[0]; break;
            default: spBar.overrideSprite = powerBar[0]; break;
        }
    }

    public void SetPlayerState(PlayerState pState)
    {
        playerState = pState;
    }
}
