using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class VisualEffectManager : MonoBehaviour
{
    public static VisualEffectManager instance;
    [SerializeField] private GameObject dashEffectPre;
    [SerializeField] private GameObject dashInAirEffectPre;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartDashEffect(Vector2 postion, bool isFacingRight)
    {
        GameObject dashEffect = Instantiate(dashEffectPre, postion, quaternion.identity);
        if(isFacingRight)
            dashEffect.GetComponentInChildren<SpriteRenderer>().flipX = true;

        Destroy(dashEffect, 1);
    }

    public void StartDashInAirEffect(Vector2 postion, bool isFacingRight)
    {
        GameObject dashEffect = Instantiate(dashInAirEffectPre, postion, quaternion.identity);
        if(isFacingRight)
            dashEffect.GetComponentInChildren<SpriteRenderer>().flipX = true;

        Destroy(dashEffect, 1);
    }

    
}
