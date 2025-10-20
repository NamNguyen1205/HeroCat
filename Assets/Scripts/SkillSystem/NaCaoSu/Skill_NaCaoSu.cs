using Unity.Mathematics;
using UnityEngine;

public class Skill_NaCaoSu : Skill_Base
{
    [Header("Bullet Prefab")]
    [SerializeField] private GameObject regularBullet;
    [SerializeField] private GameObject FireBullet;
    [SerializeField] private GameObject IceBullet;
    [SerializeField] private float bulletPower;
    [Header("Trajectory perdiction")]
    [SerializeField] private GameObject DotPrefab;
    [SerializeField] private int numberOfDots = 20;
    [SerializeField] private float spaceBetweenDots = 0.05f;
    private float BulletGravity = 3.5f;
    private Transform[] dots;
    private Vector2 confirmDirection;

    protected override void Awake()
    {
        base.Awake();
        dots = GenerateDots();
    }


    public void Bullet()
    {
        GameObject currentBullet = BulletPrefabByUpgradeType(skillUpgradeType);

        GameObject newBullet = Instantiate(currentBullet, dots[0].position, quaternion.identity);
        SkillObject_Bullet bulletObject = newBullet.GetComponent<SkillObject_Bullet>();

        bulletObject.SetUpBullet(confirmDirection * (bulletPower * 10) * 1.1f, scaleDamage);

        StartCooldown();
    }

    //thay doi prefab moi upgrade skill
    private GameObject BulletPrefabByUpgradeType(SkillUpgradeType skillUpgradeType)
    {
        switch (skillUpgradeType)
        {
            case SkillUpgradeType.NaCaoSu:
                return regularBullet;
            case SkillUpgradeType.DanLua:
                return FireBullet;
            case SkillUpgradeType.DanBang:
                return IceBullet;
            default:
                return regularBullet;
        }
    }

    public void ConfirmedDirection(Vector2 direction) => confirmDirection = direction;

    //paint bullet trajectory
    public void PredictTrajectory(Vector2 direction)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].position = GetTrajectoryPoint(direction, i * spaceBetweenDots);
        }
    }

    private Vector2 GetTrajectoryPoint(Vector2 direction, float t)
    {
        float scaleBulletPower = bulletPower * 10;
        Vector2 initialVelocity = direction * scaleBulletPower;
        Vector2 gravityEffect = 0.5f * Physics2D.gravity * BulletGravity * (t * t);
        Vector2 predictedPoint = (initialVelocity * t) + gravityEffect;
        Vector2 playerPosition = transform.root.position;
        return playerPosition + predictedPoint;
    }

    public void EnableDots(bool enable)
    {
        foreach (Transform dot in dots)
            dot.gameObject.SetActive(enable);
    }

    private Transform[] GenerateDots()
    {
        Transform[] newDots = new Transform[numberOfDots];

        for (int i = 0; i < numberOfDots; i++)
        {
            newDots[i] = Instantiate(DotPrefab, transform.position, quaternion.identity, transform).transform;
            newDots[i].gameObject.SetActive(false);
        }
        return newDots;
    }
}

