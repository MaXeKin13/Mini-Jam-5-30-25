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

    private void TryStab()
    {
        if(isInStabZone)
        {
            Debug.Log("Stab successful!");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryStab();
        }
    }
}
