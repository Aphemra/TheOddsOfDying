﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds)
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
        AlterAudio("Background Music", "Play");
    }

    public void AlterAudio(string name, string playOrStop)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist.");
            return;
        }

        if (playOrStop == "play" || playOrStop == "Play")
            s.source.Play();
        if (playOrStop == "stop" || playOrStop == "Stop")
            s.source.Stop();
    }

    public void AlterAudio(string name, float pitchModifier, bool isAdding)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist.");
            return;
        }

        if (isAdding)
            s.source.pitch += pitchModifier;
        else if (!isAdding)
            s.source.pitch -= pitchModifier;

    }

    public void PlayClick()
    {
        AlterAudio("Menu Click", "Play");
    }
}
