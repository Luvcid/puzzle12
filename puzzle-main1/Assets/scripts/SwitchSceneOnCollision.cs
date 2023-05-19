using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollision : MonoBehaviour
{
    [SerializeField] public string targetSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
