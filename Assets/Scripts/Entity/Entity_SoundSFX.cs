using UnityEngine;

public class Entity_SoundSFX : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] protected AudioDataBaseSO audioDB;
    [Header("Attack sound Name")]
    [SerializeField] private string attackMissSound;
    [SerializeField] private string attackSound;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayAttackMissSfx() => AudioManager.instance.PlaySfx(AudioToPlay(attackMissSound), audioSource);
    public void PlayAttackSfx() => AudioManager.instance.PlaySfx(AudioToPlay(attackSound), audioSource);

    private AudioClip AudioToPlay(string audioName) => audioDB.GetAudioByName(audioName).GetRandomAudio();
}
