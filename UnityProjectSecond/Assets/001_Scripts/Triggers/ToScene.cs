using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class ToScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] CanvasGroup faderCanvas = null;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float delay = 0.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PLAYER"))
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(delay);

        faderCanvas.DOFade(1.0f, fadeDuration).SetEase(Ease.OutCirc).OnComplete(() =>
        {
            if (PlayerStats.Instance != null)
                PlayerStatus.Instance.moveable = false;

            SceneManager.LoadScene(sceneName);
        });
    }
}
