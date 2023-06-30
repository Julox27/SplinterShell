using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public Image achievementImage;
    public float displayDuration = 3f;
    public float lerpSpeed = 2f;
    public Vector2 initialPosition;
    public Vector2 targetPosition;

    private float displayTimer;
    private bool isAchievementActive;

    private void Start()
    {
        achievementImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isAchievementActive)
        {
            displayTimer -= Time.deltaTime;

            if (displayTimer <= 0f)
            {
                HideAchievement();
            }
        }
    }

    public void ShowAchievement()
    {
        achievementImage.gameObject.SetActive(true);
        if (!isAchievementActive)
        {
            isAchievementActive = true;
            displayTimer = displayDuration;

            achievementImage.rectTransform.anchoredPosition = initialPosition;
            achievementImage.gameObject.SetActive(true);

            StartCoroutine(MoveAchievement());
        }
    }

    private IEnumerator MoveAchievement()
    {
        float elapsedTime = 0f;

        while (elapsedTime < displayDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / 0.5f);
            achievementImage.rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);

            yield return null;
        }

        StartCoroutine(Wait3Seconds());
    }
    IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3);
        HideAchievement();
    }
    private void HideAchievement()
    {
        achievementImage.gameObject.SetActive(false);
        isAchievementActive = false;
    }
}