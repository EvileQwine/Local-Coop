using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer renderer;
    public enum Colors
    {
        White,
        Red,
        Blue,
        Green,
        Lavender,
    }
    public Colors color;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        
        switch (color)
        {
            case Colors.White:
                renderer.material.color = new Color(0.8f, 0.8f, 0.8f, 1f);
                break;
            case Colors.Red:
                renderer.material.color = new Color(0.7484276f, 0.08942511f, 0.05883849f, 1f);
                break;
            case Colors.Green:
                renderer.material.color = new Color(0.0f, 0.75f, 0.0f, 1f);
                break;
            case Colors.Blue:
                renderer.material.color = new Color(0.0f, 0.0f, 0.75f, 1f);
                break;
            case Colors.Lavender:
                renderer.material.color = new Color(0.8901961f, 0.6235294f, 0.9647059f, 1f);
                break;
        }
    }
    void Start()
    {
        rb.AddForce(Vector2.down * Random.Range(3f, 7f), ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * Random.Range(-3f, 3f), ForceMode2D.Impulse);
        StartCoroutine(Disappear(0.4f));
    }
    IEnumerator Disappear(float f)
    {
        yield return new WaitForSeconds(f);
        Destroy(gameObject);
    }
}
