using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbagecancontroller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    /*void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactObject != null && interactObject.GetComponent<Collider2D>().bounds.Intersects(spriteRenderer.bounds))
        {
            Destroy(interactObject);

        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}