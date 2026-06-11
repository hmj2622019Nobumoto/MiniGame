using UnityEditor.Build.Content;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Hit()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore();
        }

        Destroy(gameObject);
    }
}