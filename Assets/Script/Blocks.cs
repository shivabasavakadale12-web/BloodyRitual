using UnityEngine;

public class Blocks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided but dont know why he didnt blocked");
    }
}
