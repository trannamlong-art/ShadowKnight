using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioClip rollSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip skillSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }

    public void PlayRunSound()
    {
        audioSource.PlayOneShot(runSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landSound);
    }

    public void PlayRollSound()
    {
        audioSource.PlayOneShot(rollSound);
    }

    public void PlayHealSound()
    {
        audioSource.PlayOneShot(healSound, 0.2f);
    }

    public void PlaySkillSound()
    {
        audioSource.PlayOneShot(skillSound);
    }

    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound, 0.5f);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
