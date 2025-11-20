using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public void PlayBtn()
    {
        GameManager.instance.ChangeScene("level1");
    }
}
