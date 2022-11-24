using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    public static SoldierManager Instance;
    private List<SoldierController> _soldiers;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            _soldiers = new List<SoldierController>();
            return;
        }
        Destroy(this.gameObject); 
    }

    public void AddSoldierToList(SoldierController soldier)
    {
        _soldiers.Add(soldier);
    }
    public void RemoveSoldierFromList(SoldierController soldier)
    {
        _soldiers.Remove(soldier);
    }
}
