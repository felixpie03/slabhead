using UnityEngine;
using UnityEngine.UI;

public class TeamUIColorManager : MonoBehaviour
{
    public Image player1UIColor;
    public Image player2UIColor;

    public void SetPlayerColors(Color color1, Color color2)
    {
        if (player1UIColor != null) player1UIColor.color = color1;
        if (player2UIColor != null) player2UIColor.color = color2;
    }
}
