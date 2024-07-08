using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private bool portalActive = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (!portalActive) return;

        if (nextScene == "")
        {
            Debug.LogError("Next level scene is empty");
        }
        AudioManager.instance.PlaySFX("Portal");
        SceneManager.LoadScene(nextScene);
    }

    public void ActivatePortal()
    {
        StartCoroutine(ActivatePortalAnimation());
    }

    IEnumerator ActivatePortalAnimation()
    {
        anim.SetTrigger("TriggerPortal");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        portalActive = true;

        StopCoroutine(ActivatePortalAnimation());
    }
}
