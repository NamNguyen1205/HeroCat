using UnityEngine;

public class Skill_Dash : Skill_Base
{
    private Player_Entity player;
    private Player_SkillManager skillManager;
    [SerializeField] private GameObject shadowPrefab;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponentInParent<Player_Entity>();
        skillManager = GetComponentInParent<Player_SkillManager>();
    }
    public void StartDashCooldown() => StartCooldown();

    //dash upgrade 1
    public void CreateShadow(Vector2 beforeDashingPos)
    {
        ShadowControll shadowControll = Instantiate(shadowPrefab, beforeDashingPos, Quaternion.identity).GetComponent<ShadowControll>();

        shadowControll.SetDashUpgrade(player, this);

    }
}
