using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
    Light2D light2d;
    PlayerController playerCnt;
    float lightTimer = 0f;
    
    void Start()
    {
        light2d = GetComponent<Light2D>();
        light2d.pointLightInnerAngle = 40;
        light2d.pointLightOuterAngle = 120;
        light2d.pointLightOuterRadius = (float)ItemKeeper.hasLights;
        playerCnt = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, playerCnt.angleZ - 90);

        if (ItemKeeper.hasLights > 0)
        {
            lightTimer += Time.deltaTime;

            if (lightTimer > 10f)
            {
                lightTimer = 0;
                ItemKeeper.hasLights--;
                light2d.pointLightOuterRadius = ItemKeeper.hasLights;
            }
        }
    }
}
