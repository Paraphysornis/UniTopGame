using UnityEngine;
using UnityEngine.UI;

public class VirtualPad : MonoBehaviour
{
    public float MaxLength = 70;
    public bool is4DPad = false;
    GameObject player;
    Vector2 defPos, downPos;
    public Button attackButton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        defPos = GetComponent<RectTransform>().localPosition;
        attackButton.onClick.AddListener(Attack);
    }

    public void PadDown()
    {
        downPos = Input.mousePosition;
    }

    public void PadDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 newTabPos = mousePosition - downPos;

        if (!is4DPad)
        {
            newTabPos.y = 0;
        }

        Vector2 axis = newTabPos.normalized;
        float len = Vector2.Distance(defPos, newTabPos);

        if (len > MaxLength)
        {
            newTabPos.x = axis.x * MaxLength;
            newTabPos.y = axis.y * MaxLength;
        }

        GetComponent<RectTransform>().localPosition = newTabPos;
        PlayerController plcnt = player.GetComponent<PlayerController>();
        plcnt.SetAxis(axis.x, axis.y);
    }

    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = defPos;
        PlayerController plcnt = player.GetComponent<PlayerController>();
        plcnt.SetAxis(0, 0);
    }

    public void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ArrowShoot shoot = player.GetComponent<ArrowShoot>();
        shoot.Attack();
    }
}
