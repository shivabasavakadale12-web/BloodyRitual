using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
