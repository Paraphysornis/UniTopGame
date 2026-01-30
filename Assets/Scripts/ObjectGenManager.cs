using UnityEngine;

public class ObjectGenManager : MonoBehaviour
{
    ObjectGenPoint[] objGens;
    
    void Start()
    {
        objGens = GameObject.FindObjectsOfType<ObjectGenPoint>();
    }

    void Update()
    {
        ItemData[] items = GameObject.FindObjectsOfType<ItemData>();

        for (int i = 0; i < items.Length; i++)
        {
            ItemData item = items[i];

            if (item.type == ItemType.arrow)
            {
                return;
            }
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (ItemKeeper.hasArrows == 0 && player != null)
        {
            int index = Random.Range(0, objGens.Length);
            ObjectGenPoint objgen = objGens[index];
            objgen.ObjectCreate();
        }
    }
}
