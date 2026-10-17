using UnityEngine;

[CreateAssetMenu(fileName = "Enemydata", menuName = "Scriptable Objects/Enemydata")]
public class Enemydata : ScriptableObject
{
    public float speed;
    public float attackRange;
    public float attackFrequency;
    public bool isAttacking;
    public GameObject Sister;
}
