﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayManager : BaseGamePlayManager
{
    public static GamePlayManager Singleton { get; private set; }
    public Camera inputCamera;
    [Header("Formation/Spawning")]
    public GamePlayFormation playerFormation;
    public GamePlayFormation foeFormation;
    public Transform mapCenter;
    public float spawnOffset = 5f;
    [Header("Speed/Delay")]
    public float formationMoveSpeed = 5f;
    public float doActionMoveSpeed = 8f;
    public float actionDoneMoveSpeed = 10f;
    public float beforeMoveToNextWaveDelay = 2f;
    public float moveToNextWaveDelay = 1f;
    [Header("UI")]
    public Transform uiCharacterStatsContainer;
    public UICharacterStats uiCharacterStatsPrefab;
    public UICharacterActionManager uiCharacterActionManager;
    public CharacterEntity ActiveCharacter { get; private set; }
    public Stage CastedStage { get { return PlayingStage as Stage; } }

    /// <summary>
    /// 地图中心位置
    /// </summary>
    public Vector3 MapCenterPosition
    {
        get
        {
            if (mapCenter == null)
                return Vector3.zero;
            return mapCenter.position;
        }
    }

    private void Awake()
    {
        Singleton = this;
        if (inputCamera == null)
            inputCamera = Camera.main;
        // Setup uis
        //uiCharacterActionManager.Hide();
        // 设置玩家阵型
        playerFormation.isPlayerFormation = true;
        playerFormation.foeFormation = foeFormation;
        //设置敌人阵型
        foeFormation.ClearCharacters();
        foeFormation.isPlayerFormation = false;
        foeFormation.foeFormation = playerFormation;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        //if (uiPauseGame.IsVisible())
        //{
        //    Time.timeScale = 0;
        //    return;
        //}

        //if (IsAutoPlay != isAutoPlayDirty)
        //{
        //    if (IsAutoPlay)
        //    {
        //        uiCharacterActionManager.Hide();
        //        if (ActiveCharacter != null)
        //            ActiveCharacter.RandomAction();
        //    }
        //    isAutoPlayDirty = IsAutoPlay;
        //}

        //Time.timeScale = !isEnding && IsSpeedMultiply ? 2 : 1;

        //if (Input.GetMouseButtonDown(0) && ActiveCharacter != null && ActiveCharacter.IsPlayerCharacter)
        //{
        //    Ray ray = inputCamera.ScreenPointToRay(InputManager.MousePosition());
        //    RaycastHit hitInfo;
        //    if (!Physics.Raycast(ray, out hitInfo))
        //        return;

        //    var targetCharacter = hitInfo.collider.GetComponent<CharacterEntity>();
        //    if (targetCharacter != null)
        //    {
        //        if (ActiveCharacter.DoAction(targetCharacter))
        //        {
        //            playerFormation.SetCharactersSelectable(false);
        //            foeFormation.SetCharactersSelectable(false);
        //        }
        //    }
        //}
    }

    public void StartGame()
    {
        NewWave();//下一次战斗
        //NewTurn();//下一回合
    }

    public void NewWave()
    {
        PlayerItem[] characters;
        StageFoe[] foes;
        var wave = CastedStage.waves;
        if (!wave.useRandomFoes && wave.foes.Length > 0)//判断是否随机敌人
        {
            foes = wave.foes;
        }
        else
        {
            foes = CastedStage.RandomFoes().foes;
        }
           

        //characters = new PlayerItem[foes.Length];
        //for (var i = 0; i < characters.Length; ++i)
        //{
        //    var foe = foes[i];
        //    if (foe != null && foe.character != null)
        //    {
        //        var character = PlayerItem.CreateActorItemWithLevel(foe.character, foe.level);
        //        characters[i] = character;
        //    }
        //}

        ////foeFormation.SetCharacters(characters);
        //foeFormation.Revive();
    }

    public void NewTurn()
    {
        if (ActiveCharacter != null)
            ActiveCharacter.currentTimeCount = 0;

        CharacterEntity activatingCharacter = null;
        var maxTime = int.MinValue;
        List<BaseCharacterEntity> characters = new List<BaseCharacterEntity>();
        characters.AddRange(playerFormation.Characters.Values);
        characters.AddRange(foeFormation.Characters.Values);
        for (int i = 0; i < characters.Count; ++i)
        {
            CharacterEntity character = characters[i] as CharacterEntity;
            if (character != null)
            {
                if (character.Hp > 0)
                {
                    int spd = (int)character.GetTotalAttributes().spd;
                    if (spd <= 0)
                        spd = 1;
                    character.currentTimeCount += spd;
                    if (character.currentTimeCount > maxTime)
                    {
                        maxTime = character.currentTimeCount;
                        activatingCharacter = character;
                    }
                }
                else
                    character.currentTimeCount = 0;
            }
        }
        ActiveCharacter = activatingCharacter;
        ActiveCharacter.DecreaseBuffsTurn();
        ActiveCharacter.DecreaseSkillsTurn();
        ActiveCharacter.ResetStates();
        if (ActiveCharacter.Hp > 0)
        {
            if (ActiveCharacter.IsPlayerCharacter)
            {
                if (IsAutoPlay)
                    ActiveCharacter.RandomAction();
                else
                    uiCharacterActionManager.Show();
            }
            else
                ActiveCharacter.RandomAction();
        }
        else
            ActiveCharacter.NotifyEndAction();
    }

    /// <summary>
    /// This will be called by Character class to show target scopes or do action
    /// </summary>
    /// <param name="character"></param>
    public void ShowTargetScopesOrDoAction(CharacterEntity character)
    {
        var allyTeamFormation = character.IsPlayerCharacter ? playerFormation : foeFormation;
        var foeTeamFormation = !character.IsPlayerCharacter ? playerFormation : foeFormation;
        allyTeamFormation.SetCharactersSelectable(false);
        foeTeamFormation.SetCharactersSelectable(false);
        if (character.Action == CharacterEntity.ACTION_ATTACK)
            foeTeamFormation.SetCharactersSelectable(true);
        else
        {
            switch (character.SelectedSkill.CastedSkill.usageScope)
            {
                case SkillUsageScope.Self:
                    character.selectable = true;
                    break;
                case SkillUsageScope.Ally:
                    allyTeamFormation.SetCharactersSelectable(true);
                    break;
                case SkillUsageScope.Enemy:
                    foeTeamFormation.SetCharactersSelectable(true);
                    break;
                case SkillUsageScope.All:
                    allyTeamFormation.SetCharactersSelectable(true);
                    foeTeamFormation.SetCharactersSelectable(true);
                    break;
            }
        }
    }

    public List<BaseCharacterEntity> GetAllies(CharacterEntity character)
    {
        if (character.IsPlayerCharacter)
            return playerFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
        else
            return foeFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
    }

    public List<BaseCharacterEntity> GetFoes(CharacterEntity character)
    {
        if (character.IsPlayerCharacter)
            return foeFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
        else
            return playerFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
    }

    public void NotifyEndAction(CharacterEntity character)
    {
        if (character != ActiveCharacter)
            return;

        if (!playerFormation.IsAnyCharacterAlive())
        {
            ActiveCharacter = null;
            StartCoroutine(LoseGameRoutine());
        }
        else if (!foeFormation.IsAnyCharacterAlive())
        {
            ActiveCharacter = null;
            //if (CurrentWave >= CastedStage.waves.Length)
            //{
            //    StartCoroutine(WinGameRoutine());
            //    return;
            //}
            //StartCoroutine(MoveToNextWave());
        }
        else
            NewTurn();
    }

    public override void OnRevive()
    {
        base.OnRevive();
        playerFormation.Revive();
        NewTurn();
    }

    public override int CountDeadCharacters()
    {
        return playerFormation.CountDeadCharacters();
    }
}
