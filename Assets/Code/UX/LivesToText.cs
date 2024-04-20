using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesToText : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    public void LivesText(int lives)
    {
        livesText.text = $"Lives: {lives}";
    }
}
