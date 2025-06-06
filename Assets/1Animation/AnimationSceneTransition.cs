using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneTransition : MonoBehaviour
{
    private Animator animator;
    private int currentSceneIndex;
    private bool animationFinished = false;

    private void Start()
    {
        // ��ȡAnimator���
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("δ�ҵ�Animator�����");
            return;
        }

        // ��ȡ��ǰ��������
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ע�ᶯ�������¼�
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;
        Invoke("OnAnimationFinished", animationLength);
    }

    private void OnAnimationFinished()
    {
        animationFinished = true;
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // ����Ƿ�����һ������
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("û�и��ೡ���ɼ��أ�");
        }
    }
}