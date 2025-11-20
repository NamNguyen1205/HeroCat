using UnityEngine;

public class Object_NpcBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject interactButton;

    protected Vector2 hidenPosition = new Vector2(9999, 9999);

    public void Interact()
    {
        
    }

    protected virtual void ShowInteractBtn()
    {
        interactButton.transform.position = (Vector2)transform.position + Vector2.up * 0.5f;
    }
    
    protected virtual void HideInteractBtn()
    {
        interactButton.transform.position = hidenPosition;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            ShowInteractBtn();
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            HideInteractBtn();
    }
}
