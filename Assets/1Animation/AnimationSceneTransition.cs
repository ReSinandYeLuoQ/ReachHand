using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneTransition : MonoBehaviour
{
    private Animator animator;
    private int currentSceneIndex;
    private bool animationFinished = false;

    private void Start()
    {
        // 获取Animator组件
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("未找到Animator组件！");
            return;
        }

        // 获取当前场景索引
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 注册动画结束事件
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
        // 检查是否有下一个场景
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("没有更多场景可加载！");
        }
    }
}