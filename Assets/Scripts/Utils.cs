using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static bool c_1 = false;
    public static int cave_checkpoints = 0;
    public static bool riddle = false;
    public static bool error = false;
    public static float volume = 1;
    public static float SFX = 1;

    public static void addCheckpoint()
    {
        cave_checkpoints++;
        Debug.Log(cave_checkpoints);
    }
    public static void subsCheckpoint(int num)
    {
        cave_checkpoints = -num;
        Debug.Log(cave_checkpoints);

    }

    public static void activate(int num)
    {
        if (num == 1)
            c_1 = true;
        if (num == 2)
            riddle = true;
    }
    public static void Error(bool e)
    {
        error = e;
    }
    public static void ChangeVolume(float v)
    {
        volume = v;
        Debug.Log("volume: " + volume);
    }
    public static void ChangeSFX(float v)
    {
        SFX = v;
        Debug.Log("sfx: " + SFX);

    }


}
