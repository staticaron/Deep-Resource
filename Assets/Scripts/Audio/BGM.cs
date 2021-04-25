using UnityEngine;

public class BGM : MonoBehaviour
{
    //Singletons
    public static BGM instance;

    private AudioSource bgmPlayer;
    [SerializeField]
    private AudioSource hurtPlayer;
    [SerializeField]
    private AudioSource hitPlayer;

    [SerializeField]
    private AudioClip hurt, hit;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bgmPlayer = GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayHurt()
    {
        hurtPlayer.PlayOneShot(hurt);
    }

    public void PlayHit()
    {
        hurtPlayer.PlayOneShot(hit);
    }

    [ContextMenu("IS BGM PLaying")]
    public void IsPlayingBGM()
    {
        if (bgmPlayer.isPlaying)
        {
            Debug.Log("True : BGM");
        }
        else
        {
            Debug.Log("False : BGM");
        }
    }
}
