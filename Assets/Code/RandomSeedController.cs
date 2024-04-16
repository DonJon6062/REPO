using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeedController : MonoBehaviour
{
    string currentSeed;

    private void Awake()
    {
        GenerateRandomSeed();
    }

    public void GenerateRandomSeed() 
    {
        int tempSeed = (int)System.DateTime.Now.Ticks;
        currentSeed = tempSeed.ToString();

        Random.InitState(tempSeed);
    }

    public void SetRandomSeed(string seed = "") 
    {
        currentSeed = seed;

        int tempSeed = 0;

        if (isNumeric(seed))
            tempSeed = System.Int32.Parse(seed);
        else
            tempSeed = seed.GetHashCode();

        Random.InitState(tempSeed);
    }
    public void SetRandomSeed(int seed)
    {
        currentSeed = seed.ToString();
        int tempSeed = seed;
        Random.InitState(tempSeed);
    }

    //Copy Seed to Clipboard
    public void CopySeedToClipboard() => GUIUtility.systemCopyBuffer = currentSeed;

    //Check if Seed is All numbers
    public static bool isNumeric(string s)
    {
        return int.TryParse(s, out int n);
    }
}
