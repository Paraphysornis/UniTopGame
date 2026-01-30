using UnityEngine;

public class ObjectGenPoint : MonoBehaviour
{
    public GameObject objPrefab;
    
    public void ObjectCreate()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(objPrefab, pos, Quaternion.identity);
    }
}
