using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    public static SoldierManager Instance;
    private List<SoldierController> _soldiers;
    private Transform _leftmostSoldier;
    private Transform _rightmostSoldier;
    public Action OnSoldierDestroy;
    public Action OnSoldierAdded;
    public Action OnEverySoldierGotCover;

    private int _numberOfSoldiersGotCover;
    public int NumberOfSoldiersGotCover
    {
        get
        {
            return _numberOfSoldiersGotCover;
        }
        set
        {
            _numberOfSoldiersGotCover = value;
            if(_numberOfSoldiersGotCover == _soldiers.Count)
            {
                OnEverySoldierGotCover?.Invoke();
            }
        }
    }

    private void OnEnable()
    {
        if (LevelManager.Instance == null) return;
        LevelManager.Instance.OnFinish += OnFinish;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnFinish -= OnFinish;
    }

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

    private void Start()
    {
        LevelManager.Instance.OnFinish += OnFinish;
    }

    public void AddSoldierToList(SoldierController soldier)
    {
        _soldiers.Add(soldier);
        CheckIfLeftmostRightmost(soldier);
        OnSoldierAdded?.Invoke();
    }

    public void RemoveSoldierFromList(SoldierController soldier)
    {
        _soldiers.Remove(soldier);
        ReCalculateLeftmostRightmost();
        OnSoldierDestroy?.Invoke();
    }

    public SoldierController GetFirstSoldier()
    {
        if(_soldiers.Count > 0)
        {
            return _soldiers[0];
        }
        else
        {
            return null;
        }
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

    private void ReCalculateLeftmostRightmost()
    {
        _leftmostSoldier = null;
        _rightmostSoldier = null;
        foreach (var soldier in _soldiers)
        {
            CheckIfLeftmostRightmost(soldier);
        }
    }

    private void CheckIfLeftmostRightmost(SoldierController soldier)
    {
        if (CheckIfLeftmost(soldier.transform))
        {
            _leftmostSoldier = soldier.transform;
        }
        if (CheckIfRightmost(soldier.transform))
        {
            _rightmostSoldier = soldier.transform;
        }
    }

    public Vector3 GetLeftmostPosition()
    {
        return _leftmostSoldier.position;
    }

    public Vector3 GetRightmostPosition()
    {
        return _rightmostSoldier.position;
    }

    private void OnFinish()
    {
        LevelManager.Instance.SetCrouchingPositionsAndChangeStates(_soldiers);
    }

    public SoldierController GetVictimSoldierToKill()
    {
        if (_soldiers.Count > 1)
        {
            return _soldiers[1];
        }
        else
        {
            return null;
        }
    }

    public void UnParentAllSoldiers()
    {
        for (int i = 1; i < _soldiers.Count; i++)
        {
            _soldiers[i].transform.SetParent(null);
        }
    }
    public void SetParentForAllSoldiers()
    {
        for (int i = 1; i < _soldiers.Count; i++)
        {
            _soldiers[i].transform.SetParent(_soldiers[0].transform);
        }
    }

    public int GetSoldierCount()
    {
        return _soldiers.Count;
    }

    public bool CanLastGuyShoot()
    {
        return _soldiers.Count == NumberOfSoldiersGotCover;
    }
}