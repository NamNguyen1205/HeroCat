using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject uiSkillTree;
    [SerializeField] private GameObject uiCharacter;

    private bool skillTreeActive = false;
    private bool characterActive = false;

    private void Awake()
    {
        uiSkillTree.SetActive(false);
        uiCharacter.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            uiSkillTree.SetActive(!skillTreeActive);
            skillTreeActive = !skillTreeActive;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            uiCharacter.SetActive(!characterActive);
            characterActive = !characterActive;
        }
    }

}
