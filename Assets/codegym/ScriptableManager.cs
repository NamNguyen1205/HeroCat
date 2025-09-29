using Unity.Mathematics;
using UnityEngine;

public class ScriptableManager : MonoBehaviour
{

    public item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(item.prefab, transform.position, quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
