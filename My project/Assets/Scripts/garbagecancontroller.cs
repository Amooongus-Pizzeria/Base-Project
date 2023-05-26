using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbagecancontroller : MonoBehaviour
{
    public GameObject interactObject;
    private SpriteRenderer spriteRenderer;
    public Vector3 minScale;
    public float scalingSpeed;
    public float scalingDuration;


    //Start is called before the first frame update
     private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Update is called once per frame
    void Update()
    {
        if (interactObject != null && interactObject.GetComponent<Collider2D>().bounds.Intersects(spriteRenderer.bounds))
        {
            interactObject.transform.Rotate(360f, 0f, 0f);
            Destroy(interactObject);

        }
    }
}