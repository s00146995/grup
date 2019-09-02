using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torch;
    bool activated = false;
    public RayCaster ray;

    void Update()
    {
        if (Input.GetKeyDown("t") && ray.itemCount > 0 && activated == false)
        {
            torch.SetActive(true);
            ray.itemCount--;
            activated = true;
        }

        else if (Input.GetKeyDown("t") && activated == true)
        {
            torch.SetActive(false);
            ray.itemCount++;
            activated = false;
        }
    }
}
