using UnityEngine;

public class Vfx_AutoControll : MonoBehaviour
{
    private bool CanDestroy = true;
    private float destroyDelay = 1f;
    [SerializeField] private float minX = -0.3f;
    [SerializeField] private float maxX = 0.3f;
    [SerializeField] private float minY = -0.3f;
    [SerializeField] private float maxY = 0.3f;

    private void Start()
    {
        ChangePosition();
        ChangeRotation();

        if(CanDestroy)
            Destroy(gameObject, destroyDelay);
    }

    private void ChangePosition()
    {
        float offSetX = Random.Range(minX, maxX);
        float offSetY = Random.Range(minY, maxY);

        transform.position += new Vector3(offSetX, offSetY);
    }

    private void ChangeRotation()
    {
        float angleZ = Random.Range(0, 360f);

        transform.Rotate(0, 0, angleZ);
    }
}
