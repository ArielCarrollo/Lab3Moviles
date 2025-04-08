using UnityEngine;

[CreateAssetMenu(fileName = "Score_LifeData", menuName = "ScriptableObjects/ScoreLifeData")]
public class Score_LifeDataSO : ScriptableObject
{
    public int currentScore;
    public int currentlife;
    public int MaxScore;
    public void ResetScore()
    {
        currentScore = 0;
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
        if (currentScore > MaxScore)
        {
            MaxScore = currentScore;
        }
    }
    public void RestLife(int amount)
    {
        currentlife -= amount;
    }
}
