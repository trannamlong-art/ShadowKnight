using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioClip attackSound => GetComponent<EnemyController>().Data.attackSound;
    private AudioClip summonSOund => GetComponent<EnemyController>().Data.summonSound;
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


    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound, 0.5f);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    public void PlaySummonSound()
    {
        audioSource.PlayOneShot(summonSOund);
    }
}
