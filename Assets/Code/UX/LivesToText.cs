using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesToText : MonoBehaviour
{
    public TMP_Text livesText;

    public void LivesText(int lives)
    {
        livesText.text = $"Lives: {lives}";
    }
}
