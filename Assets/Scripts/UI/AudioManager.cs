using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip restSound;
    [SerializeField] private AudioClip openUpgradePanelSound;
    [SerializeField] private AudioClip changeRespawnPointSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
    public void PlayRestSound()
    {
        audioSource.PlayOneShot(restSound, 0.3f);
    }
    public void PlayOpenUpgradePanelSound()
    {
        audioSource.PlayOneShot(openUpgradePanelSound, 0.3f);
    }
    public void PlayChangeRespawnPointSound()
    {
        audioSource.PlayOneShot(changeRespawnPointSound, 0.3f);
    }
}
