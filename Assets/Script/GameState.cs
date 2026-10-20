using UnityEngine;

public static class GameState
{
    public static bool Over;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetState() { Over = false; Time.timeScale = 1f; }

    public static void EndGame(string reason)
    {
        if (Over) return;
        Over = true;
        Debug.Log("Game over: " + reason);
        Time.timeScale = 0f; 
    }
}