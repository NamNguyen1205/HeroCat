using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Entity_VFX : MonoBehaviour
{
    private SpriteRenderer sr;
    [Header("On Damage Vfx")]
    [SerializeField] private Material onDamageMaterial;
    private Material originalMaterial;
    private Coroutine vfxTakeDamageCo;
    [SerializeField] private float vfxTakeDamageDuration = 0.2f;
    [SerializeField] private GameObject onHitVfx;
    [SerializeField] private Color onHitVfxColor;
    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        originalMaterial = sr.material;
    }

    public void PlayOnTakeDamageVfx()
    {
        if (vfxTakeDamageCo != null)
            StopCoroutine(vfxTakeDamageCo);

        vfxTakeDamageCo = StartCoroutine(PerformVfx());
    }

    private IEnumerator PerformVfx()
    {
        sr.material = onDamageMaterial;
        yield return new WaitForSeconds(vfxTakeDamageDuration);
        sr.material = originalMaterial;
    }

    public void CreateOnHitVfxPrefab()
    {
        GameObject onHitvfx = Instantiate(onHitVfx, transform.position, quaternion.identity);
        onHitvfx.GetComponentInChildren<SpriteRenderer>().color = onHitVfxColor;
    }
}
