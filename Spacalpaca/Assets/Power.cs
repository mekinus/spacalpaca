using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

   

    public Player thePlayer;

    public int sp;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    private bool isActive = false;
    private SpriteMask mask;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GetSpriteMask();
        GetSpriteRenderer();
        SetActiveStatus(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(isActive)

        {
            float moveLR = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
            float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 mouse = ray.origin;

            transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
        }

        InputHandler();
      
    }


    public void SetActiveStatus(bool active)
    {
        if(thePlayer.sp > 0)
        if(active)
        {
                thePlayer.SetPlayerState(Player.PlayerState.powering);
            isActive = true;
            mask.enabled = true;
            rend.enabled = true;
        }

        else 
        {
                thePlayer.SetPlayerState(Player.PlayerState.idle);
            isActive = false;
            mask.enabled = false;
            rend.enabled = false;
        }
    }

    void GetSpriteMask()
    {
        mask = GetComponent<SpriteMask>();
    }

    void GetSpriteRenderer()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void InputHandler()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (isActive)
                SetActiveStatus(false);
            else
                SetActiveStatus(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
