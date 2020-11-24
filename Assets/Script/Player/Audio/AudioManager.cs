using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public Sound[] sounds;

	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

		
		}
	}

	public void Play(string sound) {
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}


	public void PlayRandomSong() {
		int random = new int();
		random = UnityEngine.Random.Range(1, 6);

		foreach (Sound s in sounds) {

			s.source.Stop();

		}

		if (random == 1) {
			FindObjectOfType<AudioManager>().Play("SlowTheme2");
		}
		else if (random == 2) {

			FindObjectOfType<AudioManager>().Play("FastTheme2");
		}

		else if (random == 3) {

			FindObjectOfType<AudioManager>().Play("FastTheme1");
		}

		else if (random == 4) {

			FindObjectOfType<AudioManager>().Play("SlowTheme1");
		}

		else if (random == 5) {

			FindObjectOfType<AudioManager>().Play("EpicTheme1");
		}
	}


	public void RandomGoldSound() {
		int random = new int();
		random = UnityEngine.Random.Range(1, 6);

		if (random == 1) {
			FindObjectOfType<AudioManager>().Play("Coin1");
		}
		else if (random == 2) {

			FindObjectOfType<AudioManager>().Play("Coin2");
		}

		else if (random == 3) {

			FindObjectOfType<AudioManager>().Play("Coin3");
		}

		else if (random == 4) {

			FindObjectOfType<AudioManager>().Play("Coin4");
		}

		else if (random == 5) {

			FindObjectOfType<AudioManager>().Play("Coin5");
		}
	}


	public void RandomArmorhitSound() {
		int random = new int();
		random = UnityEngine.Random.Range(1, 6);

		if (random == 1) {
			FindObjectOfType<AudioManager>().Play("SwordhitArmor1");
		}
		else if (random == 2) {

			FindObjectOfType<AudioManager>().Play("SwordhitArmor2");
		}

		else if (random == 3) {

			FindObjectOfType<AudioManager>().Play("SwordhitArmor3");
		}

		else if (random == 4) {

			FindObjectOfType<AudioManager>().Play("SwordhitArmor4");
		}

		else if (random == 5) {

			FindObjectOfType<AudioManager>().Play("SwordhitArmor5");
		}
	}

	public void RandomBodyhitSound() {
		int random = new int();
		random = UnityEngine.Random.Range(1, 6);

		if (random == 1) {
			FindObjectOfType<AudioManager>().Play("SwordhitBody1");
		}
		else if (random == 2) {

			FindObjectOfType<AudioManager>().Play("SwordhitBody2");
		}

		else if (random == 3) {

			FindObjectOfType<AudioManager>().Play("SwordhitBody3");
		}

		else if (random == 4) {

			FindObjectOfType<AudioManager>().Play("SwordhitBody4");
		}

		else if (random == 5) {

			FindObjectOfType<AudioManager>().Play("SwordhitBody5");
		}
	}

}
