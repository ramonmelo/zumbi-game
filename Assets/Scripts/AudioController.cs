using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource source;
    public static AudioSource instance;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = source;
    }
}
