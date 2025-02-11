using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardUI : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // UI text reference
    public string rewardTag = "Rewards"; // Ensure all reward objects have this tag
    private int totalCollectibles; // Store the total number of collectibles

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>(); // Get UI component
        totalCollectibles = GameObject.FindGameObjectsWithTag(rewardTag).Length; // Get initial count
        UpdateRewardUI();
    }

    public void CollectReward(GameObject reward)
    {
        if (totalCollectibles > 0)
        {
            totalCollectibles--; // Manually decrease count
            Destroy(reward); // Destroy the collected reward
            UpdateRewardUI();
        }
    }

    void UpdateRewardUI()
    {
        collectibleText.text = "Rewards Left: " + totalCollectibles;
    }
}
