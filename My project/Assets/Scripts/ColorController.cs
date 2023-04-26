using UnityEngine;

public class ColorController : MonoBehaviour
{
    public float transitionTime = 1.0f;
    public Color burntColor = new Color(0.5f, 0.2f, 0.1f, 1.0f);
    public GameObject interactObject;

    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private float startTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        startTime = Time.time;
    }

    private void Update()
    {
        if (interactObject != null && interactObject.GetComponent<Collider2D>().bounds.Intersects(spriteRenderer.bounds))
        {
            // Calculate the elapsed time since the interaction started
            float elapsedTime = Time.time - startTime;

            // Calculate the ratio of elapsed time to transition time
            float ratio = Mathf.Clamp01(elapsedTime / transitionTime);

            // Lerp the sprite color from start color to burnt color
            Color lerpedColor = Color.Lerp(startColor, burntColor, ratio);

            // Update the sprite color
            spriteRenderer.color = lerpedColor;
        }
    }
}