using UnityEngine;

public class StabZone : MonoBehaviour
{
    public Sprite normal;
    public Sprite highlighted;

    public SpriteRenderer[] spriteRenderer;
    public void ChangeSprite()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            if (spriteRenderer != null)
            {
                if (spriteRenderer[i].sprite == normal)
                {
                    spriteRenderer[i].sprite = highlighted;
                }
                else
                {
                    spriteRenderer[i].sprite = normal;
                }

            }
            else
            {
                Debug.LogWarning("SpriteRenderer not found on StabZone object.");
            }
        }
    }
}
