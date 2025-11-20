using UnityEngine;

public class Entity_SoundSFX : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField] protected AudioDataBaseSO audioDB;
    [Header("Attack sound Name")]
    [SerializeField] protected string attackMissSound;
    [SerializeField] protected string attackSound;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public virtual void PlayAttackMissSfx() => AudioManager.instance.PlaySfx(AudioToPlay(attackMissSound), audioSource);
    public virtual void PlayAttackSfx() => AudioManager.instance.PlaySfx(AudioToPlay(attackSound), audioSource);

    protected virtual AudioClip AudioToPlay(string audioName) => audioDB.GetAudioByName(audioName).GetRandomAudio();
}
