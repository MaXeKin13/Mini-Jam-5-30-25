using UnityEngine;
using UnityEngine.Events;

public class StabCursor : MonoBehaviour
{
    private bool isInStabZone = false;

    public UnityEvent onCanStab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("StabZone"))
        {
            isInStabZone = true;
            Debug.Log("Entered stab zone. Press Space to stab.");
            ChangeStabSprite();
            onCanStab?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("StabZone"))
        {
            isInStabZone = false;
            ChangeStabSprite();

        }
    }



    public void TryStab()
    {
        if(isInStabZone)
        {
            Debug.Log("Stab successful!");

            GameManager.Instance.knife.Stab();

            GameManager.Instance.stabbingManager.IncreaseJiggle();

            
        }
    }

    public void ChangeStabSprite()
    {
        GameManager.Instance.stabZone.ChangeSprite();
    }

    
}
