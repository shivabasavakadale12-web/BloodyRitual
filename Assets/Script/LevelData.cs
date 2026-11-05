using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public int levelNumber;
    public float StartInterval;
    public float MinInterval;
    public int MaxAlive;
    public float ShrinkPerSecond;
    public float RitualCircleSize;
    public float playerspeed;
    public float playerTopDuration;
    public float RitualTime;
    public float LaneSwitchCooldown;

}
