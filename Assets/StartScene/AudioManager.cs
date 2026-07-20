using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("Runtime_AudioManager");
                    _instance = go.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource runningSource; // নতুন: রানিং সাউন্ডের জন্য ডেডিকেটেড সোর্স

    private AudioClip backgroundMusic;
    private AudioClip runningSound; // নতুন: রানিং সাউন্ড ক্লিপ
    [HideInInspector] public AudioClip jumpSound;
    [HideInInspector] public AudioClip slideSound;
    [HideInInspector] public AudioClip coinCollectSound;
    [HideInInspector] public AudioClip correctActionSound;
    [HideInInspector] public AudioClip gameOverSound;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            SetupAudioSources();
            LoadAudioResources();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    private void SetupAudioSources()
    {
        if (musicSource == null)
        {
            GameObject mGo = new GameObject("MusicSource");
            mGo.transform.SetParent(transform);
            musicSource = mGo.AddComponent<AudioSource>();
        }
        if (sfxSource == null)
        {
            GameObject sGo = new GameObject("SFXSource");
            sGo.transform.SetParent(transform);
            sfxSource = sGo.AddComponent<AudioSource>();
        }
        // ফিক্স: রানিং সাউন্ড সোর্স অটোমেটিক তৈরি করা
        if (runningSource == null)
        {
            GameObject rGo = new GameObject("RunningSource");
            rGo.transform.SetParent(transform);
            runningSource = rGo.AddComponent<AudioSource>();
        }

        // সব সাউন্ড 2D মোডে সেট করা হলো
        musicSource.spatialBlend = 0f;
        sfxSource.spatialBlend = 0f;
        runningSource.spatialBlend = 0f;

        // ডিফল্ট ভলিউম সেটিংস (প্রয়োজন অনুযায়ী পরিবর্তন করতে পারেন)
        musicSource.volume = 0.3f;
        runningSource.volume = 0.5f; 
    }

    private void LoadAudioResources()
    {
        Debug.Log("[AUDIO MANAGER] Loading audio clips from Resources folder...");

        backgroundMusic = Resources.Load<AudioClip>("bg_music");
        runningSound = Resources.Load<AudioClip>("sfx_run"); // নতুন: 'sfx_run' লোড করা হচ্ছে
        jumpSound = Resources.Load<AudioClip>("sfx_jump");
        slideSound = Resources.Load<AudioClip>("sfx_slide");
        coinCollectSound = Resources.Load<AudioClip>("sfx_coin");
        correctActionSound = Resources.Load<AudioClip>("sfx_success");
        gameOverSound = Resources.Load<AudioClip>("sfx_gameover");

        // রানিং ক্লিপটি সোর্সে অ্যাসাইন করে লুপ অন করা হলো
        if (runningSound != null && runningSource != null)
        {
            runningSource.clip = runningSound;
            runningSource.loop = true;
        }

        if (backgroundMusic != null)
            Debug.Log("[AUDIO MANAGER] SUCCESS: bg_music loaded successfully!");
        else
            Debug.LogError("[AUDIO MANAGER] ERROR: Failed to load 'bg_music' from Resources folder!");

        if (runningSound == null)
            Debug.LogWarning("[AUDIO MANAGER] WARNING: 'sfx_run' not found in Resources folder.");
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            if (musicSource.clip != backgroundMusic)
            {
                musicSource.clip = backgroundMusic;
                musicSource.loop = true;
            }

            if (!musicSource.isPlaying)
            {
                musicSource.Play();
                Debug.Log("[AUDIO MANAGER] bg_music forced to play/resume after scene reload.");
            }
        }
    }

    // নতুন: প্লেয়ার দৌড়ানোর সময় সাউন্ড অন/অফ করার মেথড
    public void SetRunningSoundActive(bool isActive)
    {
        if (runningSource == null || runningSound == null) return;

        if (isActive)
        {
            // প্লেয়ার মাটিতে থাকলে এবং সাউন্ড অলরেডি না চললে প্লে হবে
            if (!runningSource.isPlaying && Time.timeScale > 0f)
            {
                runningSource.Play();
            }
        }
        else
        {
            // প্লেয়ার জাম্প করলে বা গেম ওভার হলে সাময়িক পজ হবে
            if (runningSource.isPlaying)
            {
                runningSource.Pause();
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void ForceRestartBackgroundMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            Debug.Log("[AUDIO MANAGER] ForceRestartBackgroundMusic triggered after scene reload.");

            musicSource.Stop();
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.time = 0f; 
            musicSource.Play();

            // রিস্টার্টের সময় পুরোনো রানিং সাউন্ড প্লে হতে থাকলে তা সম্পূর্ণ স্টপ করা
            if (runningSource != null)
            {
                runningSource.Stop();
            }

            Debug.Log("[AUDIO MANAGER] bg_music successfully forced to play from scratch.");
        }
    }
}