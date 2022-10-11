
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public rewardHolder rewardHolder;
    public Image fillImg;
    public Text percentageText;
    //public int increasePerIteration=20;
    public float slowFactor=2f;
    private bool lerping;
    private reward currentReward;
    public delegate void fillReward();
    public static event fillReward onRewardUnlocked;
    public float increasePerIterationCal
    {
        get
        {
            return PlayerPrefs.GetFloat("value") + (currentReward.increasePerIteration / 100f);
        }

    }
    private float fill
    {
        get
        {
            return fillImg.fillAmount * 100;
        }
        set
        {
            value = fillImg.fillAmount / 100;
        }
    }
    public int currentRewardIndex
    {
        get
        {
           return  PlayerPrefs.GetInt("rewardIndex");
        }
        set
        {
            PlayerPrefs.SetInt("rewardIndex",value);
        }
    }
    private void OnEnable()
    {
        onRewardUnlocked += Controller_onRewardUnlocked;
    }
    private void OnDisable()
    {
        onRewardUnlocked -= Controller_onRewardUnlocked;
    }
    public void Controller_onRewardUnlocked()
    {
        Debug.Log("Reward Claimed !");
        PlayerPrefs.SetFloat("value", 0);
        currentReward.isClaimed = true;
        loadNext();
    }

    void Start()
    {
        fillImg.fillAmount = PlayerPrefs.GetFloat("value");        
        percentageText.text = fill + "%";
        currentReward = rewardHolder.rewards[currentRewardIndex];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lerping = true;
        }
        if (lerping)
        {
            fillImg.fillAmount = Mathf.MoveTowards(fillImg.fillAmount, increasePerIterationCal,Time.deltaTime/ slowFactor);
            percentageText.text = fill.ToString("0") + "%";
            if (isReached(fillImg.fillAmount, increasePerIterationCal))
            {
                if (fillImg.fillAmount == 1)
                {
                    onRewardUnlocked();
                }
                else
                {
                   // Debug.Log(increasePerIterationCal);
                    PlayerPrefs.SetFloat("value", fillImg.fillAmount);
                    
                }
                lerping = false;
            }

        }
    
    }

    private void loadNext()
    {
        currentRewardIndex++;
        if (currentRewardIndex >= rewardHolder.rewards.Count) return;
        // load next item //
        currentReward = rewardHolder.rewards[currentRewardIndex];
        fillImg.sprite = currentReward.icon;
        fillImg.fillAmount = 0;
        percentageText.text = fill + "%";
    }
    private bool isReached(float a, float b)
    {
        return a == b;
    }
}
