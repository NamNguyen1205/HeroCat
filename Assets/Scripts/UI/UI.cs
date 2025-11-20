using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    // [SerializeField] private GameObject uiSkillTree;
    // [SerializeField] private GameObject uiCharacter;

    public UI_SkillTree ui_SkillTree {get; private set; }
    public UI_Character ui_Character {get; private set; }
    public UI_DeathOption ui_DeathOption {get; private set; }
    // public UI_Cha

    private bool skillTreeActive = false;
    private bool characterActive = false;

    private void Awake()
    {
        ui_SkillTree = GetComponentInChildren<UI_SkillTree>(true);
        ui_Character = GetComponentInChildren<UI_Character>(true);
        ui_DeathOption = GetComponentInChildren<UI_DeathOption>(true);
       

       ui_SkillTree.InitSkillTree();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // uiSkillTree.SetActive(!skillTreeActive);
            ui_SkillTree.gameObject.SetActive(!skillTreeActive);
            skillTreeActive = !skillTreeActive;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // uiCharacter.SetActive(!characterActive);
            ui_Character.gameObject.SetActive(!characterActive);
            characterActive = !characterActive;
        }
    }

}
