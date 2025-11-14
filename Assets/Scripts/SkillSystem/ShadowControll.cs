using System.Collections;
using UnityEngine;

public class ShadowControll : MonoBehaviour
{
    private Player_Entity player;
    private Skill_Dash skill_Dash;
    private SpriteRenderer sr;
    private Sprite playerBeforeDashSprite;
    private float timeCanNotBack = 1;
    private float duration = 0;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        duration = 0;
    }

    private void Start()
    {
        SetUpShadowSprite();
    }

    private void SetUpShadowSprite()
    {
        sr.sprite = player.sr.sprite;

        if(player.isFacingRight == false)
            sr.flipX = true;
        
    }

    private void Update()
    {
        if (player == null) return;
        duration += Time.deltaTime;

        if (player.input.Player.Dash.WasPressedThisFrame() && timeCanNotBack < duration)
            SwapPlayer();

        FadeOutEffect();
        DestroyShadowIfNotUse();
    }

    private void SwapPlayer()
    {
        player.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void DestroyShadowIfNotUse()
    {
        if (skill_Dash.OnCooldown()) return;

        Destroy(gameObject);
    }

    public void SetDashUpgrade(Player_Entity player, Skill_Dash skill_Dash)
    {
        this.player = player;
        this.skill_Dash = skill_Dash;
    }

    private void FadeOutEffect()
    {
        float duration = skill_Dash.GetCoolDown();

        Color color = sr.color;
        color.a -= Time.deltaTime / duration;
        sr.color = color;

    }


}
