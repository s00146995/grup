using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player
    public RayCaster ray;
    public int hp = 50;
    public bool isMoving = false;

    public GameObject journal;
    bool active = false;

    void Update()
    {
        PlayerMovement();
        OpenJournal();
        Heal();
    }

    void PlayerMovement()
    {
       float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0)
        {
            Vector3 playerMovement = new Vector3(horizontal, 0f, 0f).normalized * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
        else
        {
            Vector3 playerMovement = new Vector3(0, 0f, vertical).normalized * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }  

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void OpenJournal()
    {
        if (Input.GetKeyDown(KeyCode.J) && active == false)
        {
            journal.SetActive(true);
            active = true;
        }

        else if (Input.GetKeyDown(KeyCode.J) && active == true)
        {
            journal.SetActive(false);
            active = false;
        }
    }

    void Heal()
    {
        if (ray.potionCount > 0)
        {
            if (Input.GetKeyDown("h"))
            {
                hp = hp + 50;
                ray.potionCount--;
            }
        }
    }
}
