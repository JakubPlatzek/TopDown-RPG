
using UnityEngine;
[ExecuteInEditMode]
public class IsometricSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -10);
    }
}
