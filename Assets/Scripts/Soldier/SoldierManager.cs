using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    public static SoldierManager Instance;
    private List<SoldierController> _soldiers;
    private Transform _leftmostSoldier;
    private Transform _rightmostSoldier;

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
        if (CheckIfLeftmost(soldier.transform))
        {
            _leftmostSoldier = soldier.transform;
        }
        if (CheckIfRightmost(soldier.transform))
        {
            _rightmostSoldier = soldier.transform;
        }
    }
    public void RemoveSoldierFromList(SoldierController soldier)
    {
        _soldiers.Remove(soldier);
    }

    public SoldierController GetFirstSoldier()
    {
        return _soldiers[0];
    }

    public bool IsContains(SoldierController soldier)
    {
        return _soldiers.Contains(soldier);
    }
    private bool CheckIfLeftmost(Transform soldier)
    {
        if (_leftmostSoldier == null) return true;
        if (soldier.position.x < _leftmostSoldier.position.x) return true;
        return false;
        
    }
    private bool CheckIfRightmost(Transform soldier)
    {
        if (_rightmostSoldier == null) return true;
        if (soldier.position.x > _rightmostSoldier.position.x) return true;
        return false;
    }
    public Vector3 GetLeftmostPosition()
    {
        return _leftmostSoldier.position;
    }
    public Vector3 GetRightmostPosition()
    {
        return _rightmostSoldier.position;
    }

}
