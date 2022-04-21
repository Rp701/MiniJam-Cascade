using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool acquiredHead;
    public bool acquiredHandle;
    public bool acquiredShovel;
    public bool unlockedPage1;
    public bool unlockedPage2;
    public bool unlockedPage3;

    private void Start()
    {
        acquiredHead = false;
        acquiredHandle = false;
        acquiredShovel = false;
        unlockedPage1 = false;
        unlockedPage2 = false;
        unlockedPage3 = false;
    }
}
