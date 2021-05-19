using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakScore : MonoBehaviour
{
    public int score;
    public int streak;

    public void GererStreakUp(GameObject joueur)
    {
        streak += 1;
        Debug.Log(streak + joueur.name);
    }

    public void GererStreakReset(GameObject joueur)
    {
        streak = 0;
        Debug.Log(streak + "reset" + joueur.name);
    }

    public int GetStreak(GameObject joueur)
    {
        return streak;
    }

    public void ScoreUp(GameObject joueur)
    {
        score += 100 * streak;
        Debug.Log(score + joueur.name);
    }

    public int GetScore(GameObject joueur)
    {
        return score;
    }
}
