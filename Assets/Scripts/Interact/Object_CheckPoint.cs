using UnityEngine;
using UnityEngine.Rendering;

public class Object_CheckPoint : MonoBehaviour
{
    public bool isChecked = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void PlayAnimation()
    {
        anim.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == false)
            return;

        isChecked = true;
        PlayAnimation();
    }

}
