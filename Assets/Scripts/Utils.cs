using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static bool c_1 = false;
    public static int cave_checkpoints = 0;
    public static bool riddle = false;

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
    

}
