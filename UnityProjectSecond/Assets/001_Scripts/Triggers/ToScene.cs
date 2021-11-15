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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PLAYER"))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        faderCanvas.DOFade(1.0f, fadeDuration).SetEase(Ease.OutCirc).OnComplete(() =>{
            PlayerStatus.Instance.moveable = false;
            SceneManager.LoadScene(sceneName);
        });
    }
}
