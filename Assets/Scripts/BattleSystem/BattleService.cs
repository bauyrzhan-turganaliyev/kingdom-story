﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace turganaliyev.BattleSystem
{
    public class BattleService : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private BattleCreateService _battleCreateService;
        [SerializeField] private BattleTime _battleTime;
        [SerializeField] private GameObject _battleSetupPanel;

        public Action OnServiceOpened;
        public Action OnServiceExit;
        public void Init()
        {
            _battleCreateService.Init(this);
            _battleSetupPanel.SetActive(false);
        }

        public void OnClick()
        {
            _transform.SetAsLastSibling();
            _battleSetupPanel.SetActive(true);
            OnServiceOpened?.Invoke();
        }
        
        public void OnExit()
        {
            _transform.SetAsLastSibling();
            _battleSetupPanel.SetActive(false);
            OnServiceExit?.Invoke();
        }

        public void OnClickBeginBattle(List<Battler> alias, List<Battler> enemies)
        {
            print("Clicked");
            _battleTime.PrepairBattle(alias, enemies);
        }
    }
}