using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private string itemTag = "Item";
    [SerializeField] private string bedTag = "Bed";
    [SerializeField] private string potionTag = "Potion";

    public Transform rayFollow;
    private GameObject raycastedObject;
    private RaycastHit selectedObject;
    float distance;


    private Material material;
    private Color normalColor;
    private Color selectedColor;

    private float animationTime = 0.9f;
    private float treshold = 3f;
    public PlayerController player;

    public int itemCount = 0;
    public int potionCount = 0;

    public GameObject canvas;

    private void Awake()    // Sets Highlight object values
    {
        material = GetComponent<MeshRenderer>().material;
        normalColor = material.color;

        selectedColor = new Color(
            Mathf.Clamp01(normalColor.r * treshold),
            Mathf.Clamp01(normalColor.g * treshold),
            Mathf.Clamp01(normalColor.b * treshold)
            );

    }

    void Update()
    {
        RayCast();
        ItemInteract();
        BedInteract();
        PotionInteract();
    }

    private void RayCast()
    {
        Vector3 forward = rayFollow.transform.TransformDirection(Vector3.forward) * 3f; // Sets up ray forward from source
        Debug.DrawRay(transform.position, forward, Color.green); // Draws the Ray in Scene

        if (Physics.Raycast(transform.position, (forward), out selectedObject))  // If ray hits certain object
        {   
            
            distance = selectedObject.distance; // Calculates distance between object and ray source
        }

    }

    public virtual void ItemInteract()
    {
        if (rayFollow == null)
            rayFollow = transform;

        if (selectedObject.transform != null)
        {
            var selection = selectedObject.transform;
            if (selection.CompareTag(itemTag) && distance < 1.5f) // If object is certain distance away
            {
                raycastedObject = selectedObject.collider.gameObject;
                HighlightInitiate();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("INTERACT");
                    raycastedObject.SetActive(false);   // Deactivates object
                    itemCount+=1;
                    
                }
            }
            else
            {
                HighlightStop();

            }
        }
    }

    public virtual void BedInteract() // Method used for interacting with a bed
    {
        if (rayFollow == null)
            rayFollow = transform;

        if (selectedObject.transform != null)
        {
            var selection = selectedObject.transform;
            if (selection.CompareTag(bedTag) && distance < 1.5f)
            {
                raycastedObject = selectedObject.collider.gameObject;
                HighlightInitiate();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("INTERACT WITH BED");
                    canvas.SetActive(true);
                }
            }
            else
            {
                HighlightStop();

            }
        }
    }

    public virtual void PotionInteract()
    {
        if (rayFollow == null)
            rayFollow = transform;

        if (selectedObject.transform != null)
        {
            var selection = selectedObject.transform;
            if (selection.CompareTag(potionTag) && distance < 1.5f) // If object is certain distance away
            {
                raycastedObject = selectedObject.collider.gameObject;
                HighlightInitiate();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("INTERACT");
                    raycastedObject.SetActive(false);   // Deactivates object
                    potionCount += 1;

                }
            }
            else
            {
                HighlightStop();

            }
        }
    }


    public void HighlightInitiate() // Start of Highlight objects
    {
        iTween.ColorTo(raycastedObject, iTween.Hash(
            "color", selectedColor,
            "time", animationTime,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.pingPong
            ));
    }

    public void HighlightStop() // Stops highlighting objects
    {
        if (raycastedObject != null)
        {
            iTween.Stop(raycastedObject);
            material.color = normalColor;
        }
    }
}
