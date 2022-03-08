using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "diffuculty";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private const int MIN_DIFFUCULTY = 0;
    private const int MAX_DIFFUCULTY = 10;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFUCULTY && difficulty <= MAX_DIFFUCULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    internal static void SetDifficulty(float value)
    {
        throw new NotImplementedException();
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
