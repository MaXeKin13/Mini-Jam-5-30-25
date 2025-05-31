using UnityEngine;

public class StabCursor : MonoBehaviour
{
    private bool isInStabZone = false;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("StabZone"))
        {
            isInStabZone = true;
            Debug.Log("Entered stab zone. Press Space to stab.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("StabZone"))
        {
            isInStabZone = false;
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

    
}
