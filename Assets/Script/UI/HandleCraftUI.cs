using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCraftUI : MonoBehaviour
{
    // Start is called before the first frame update

    //‘åŒ³‚ÌPanelUI‚ğíœ‚µ‚Äƒpƒlƒ‹•\¦‚ğÁ‚·
    public void CloseCraftPanel()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        
    }
}
