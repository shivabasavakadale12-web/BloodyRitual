using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public int levelNumber;
    public int Year;
    [SerializeField] float startInterval;
    public float StartInterval => startInterval;
    [SerializeField] float minInterval;
    public float MinInterval => minInterval;
    [SerializeField] int maxAlive;
    public int MaxAlive => maxAlive;
    [SerializeField] float ShrinkperSecond;
    public float ShrinkPerSecond => ShrinkperSecond;

    public float RitualCircleSize;
    public float playerspeed;
    public float playerTopDuration;
    public float RitualTime;
    public float LaneSwitchCooldown;

}
