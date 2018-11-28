using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

	// Use this for initialization
	void Awake()
	{
	    if (instance == null)
	    {
	        instance = this; // do not duplicate the audio manager (and therefore the audio)
	    }
	    else
	    {
	        Destroy(gameObject); // destroy if duplicate
	        return;
	    }
        DontDestroyOnLoad(gameObject); // keep audiomanager persistant (one audio manager to deal with all our scenes rather than multiple)

	    foreach (var s in sounds)
	    {
	        s.source = gameObject.AddComponent<AudioSource>();
	        s.source.clip = s.clip;

	        s.source.volume = s.volume;
	        s.source.pitch = s.pitch;
	        s.source.loop = s.loop;
	    }
	}

    void Start()
    {
        // Play("menuMusic"); // Play ambience on game start
    }
	
	// Update is called once per frame
	public void Play(string name)
	{
	   var s = Array.Find(sounds, sound => sound.name == name);

	    if (s == null)
	    {
            Debug.LogWarning("Sound: " + name + " not found!");
	        return;
	    }

       s.source.Play();
	}

    public void Stop(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }
}
