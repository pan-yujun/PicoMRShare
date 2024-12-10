using System.Collections;
using UnityEngine;
using XTools.UnityEngine;

/// <summary>
/// 点击左右箭头切换台子上的模型
/// </summary>
public class GFLQInteract : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Animator animator;
    public string appearCondition = "Chuxian";
    public string disappearCondition = "Xiaoshi";
    public float disappearTime = 0.1f;
    public float appearTime = 0.7f;
    private Coroutine cor;
    private int i = 0;
    private ModelIntroductionCtl modelIntroductionCtl;

    private void Start()
    {
        modelIntroductionCtl = GetComponentInChildren<ModelIntroductionCtl>(true);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        i = 0;
        gameObjects[0].SetActive(true);
        gameObjects[0].GetComponent<Animator>().SetTrigger(appearCondition);
        if (modelIntroductionCtl != null)
            modelIntroductionCtl.CloseLastAudio();
    }



    public void NextObj()
    {
        animator.SetTrigger("Touch");
        i++;
        arrowRight.SetActive(false);

        if (i >= gameObjects.Length)
            i = 0;

        if (i == 0)
        {

            gameObjects[gameObjects.Length - 1].GetComponent<Animator>().SetTrigger(disappearCondition);


            CloseIntroduction(gameObjects[gameObjects.Length - 1]);


        }
        else
        {

            gameObjects[i - 1].GetComponent<Animator>().SetTrigger(disappearCondition);
            CloseIntroduction(gameObjects[i - 1]);


        }


        if (cor != null)
            StopCoroutine(cor);
        cor = StartCoroutine(WaitForSomeTime(arrowRight, true));

        gameObjects[i].SetActive(true);
        gameObjects[i].GetComponent<Animator>().SetTrigger(appearCondition);

    }

    public void LastObj()
    {
        animator.SetTrigger("Touch");

        i--;
        arrowLeft.SetActive(false);

        if (i < 0)
            i = gameObjects.Length - 1;

        if (i == gameObjects.Length - 1)
        {

            gameObjects[0].GetComponent<Animator>().SetTrigger(disappearCondition);
            CloseIntroduction(gameObjects[0]);

        }
        else
        {

            gameObjects[i + 1].GetComponent<Animator>().SetTrigger(disappearCondition);
            CloseIntroduction(gameObjects[i + 1]);

        }


        if (cor != null)
            StopCoroutine(cor);
        cor = StartCoroutine(WaitForSomeTime(arrowLeft, true));

        gameObjects[i].SetActive(true);
        gameObjects[i].GetComponent<Animator>().SetTrigger(appearCondition);

    }

    private IEnumerator WaitForSomeTime(GameObject arrowObj, bool active)
    {
        yield return new WaitForSeconds(disappearTime);

        //gameObjects[i].SetActive(true);
        //gameObjects[i].GetComponent<Animator>().SetTrigger(appearCondition);
        //yield return new WaitForSeconds(appearTime);
        arrowObj.SetActive(active);
        animator.Play("idle");
    }

    /// <summary>
    /// 关闭模型介绍
    /// </summary>
    /// <param name="obj"></param>
    private void CloseIntroduction(GameObject obj)
    {
        LookAtMainCamera lookAtMainCamera = obj.GetComponentInChildren<LookAtMainCamera>();
        if (lookAtMainCamera != null)
        {

            lookAtMainCamera.transform.parent.parent.gameObject.SetActive(false);
        }
    }


}
