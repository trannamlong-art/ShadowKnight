using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip musicA;
    [SerializeField] private AudioClip musicB;
    [SerializeField, Range(0f, 1f)] private float volume;

    private AudioSource[] audioSources = new AudioSource[2];

    private int index;
    private double nextMusicTime;

    private void Awake()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].playOnAwake = false;
            audioSources[i].loop = false;
            audioSources[i].spatialBlend = 0f;
        }
    }
    private void OnEnable()
    {
        index = 0;
        nextMusicTime = AudioSettings.dspTime + 1f;
    }
    private void Update()
    {
        if (musicA == null || musicB == null) return;
        if (AudioSettings.dspTime + 0.5f < nextMusicTime) return;

        AudioSource source = audioSources[index];
        source.clip = index == 0 ? musicA : musicB;
        source.volume = volume;
        source.PlayScheduled(nextMusicTime);

        index = 1 - index;
        nextMusicTime += 12.8f;
    }
}
