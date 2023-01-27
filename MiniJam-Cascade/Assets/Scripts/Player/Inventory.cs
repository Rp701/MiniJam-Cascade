using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public bool acquiredHead;
    public bool acquiredHandle;
    public bool acquiredShovel;
    public bool acquiredCarKeys;
    public bool acquiredPlank;

    private void Awake()
    {
        instance = this;
        acquiredHead = false;
        acquiredHandle = false;
        acquiredShovel = false;
        acquiredPlank = false;
        acquiredCarKeys = false;
    }
}
