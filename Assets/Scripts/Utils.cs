using UnityEngine;

public static class Sound
{
    public static float volume = 0.5f;
    public static float SFX = 0.5f;

    public static void ChangeVolume(float v)
    {
        volume = v;
        Debug.Log("volume: " + volume);
    }
    public static void ChangeSFX(float v)
    {
        SFX = v;

    }

}

public static class Cave
{
    public static int checkPoints = 0;
    public static bool npc = false;
    public static bool memory = false;

    public static void AddCheckpoint()
    {
        checkPoints++;
    }
    public static void ResetCheckPoints()
    {
        checkPoints = 0;
    }

    public static void NpcActivation(bool isActive)
    {
        npc = isActive;
    }
    public static void MemoryActivation(bool isActive)
    {
        memory = isActive;
    }
}

public static class Tutorial
{
    public static int state = 0;
    public static void NextFile()
    {
        state++;
    }
    public static void Reset()
    {
        state = 0;
    }
}
public static class MathFunctions
{
    public static float ComputeDistance(Vector3 objPos, Vector3 playerPos)
    {
        float dist = Vector3.Distance(objPos, playerPos);
        return dist;
    }
} 
