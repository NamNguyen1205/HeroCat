using UnityEngine;

public class Player_SoundSfx : Entity_SoundSFX
{
    [SerializeField] private string dashSoundSfx;

    public virtual void PlayDashSfx() => AudioManager.instance.PlaySfx(AudioToPlay(dashSoundSfx), audioSource);
}
