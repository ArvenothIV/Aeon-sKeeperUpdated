using UnityEngine;
using System.Collections;
using System;

//this script is used to set all the players starting stats based on their class
//as well as to update stats when the player gains a level

public class CharStats : MonoBehaviour {
	private BaseCharacter _player;
	GameObject js;
	public PlayerInventory jScript;
	public bool addExp;


	void Awake(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		_player = new BaseCharacter();
		_player.Awake();
		addExp = false;
		js = GameObject.FindGameObjectWithTag("PlayerInventory");
		jScript = js.GetComponent<PlayerInventory>();

		SetStats();

		if(PlayerPrefs.HasKey("HP")){
			jScript.fullHP = PlayerPrefs.GetInt("HP");
			jScript.currentHP = jScript.fullHP;
		}
		if(PlayerPrefs.HasKey("MP")){
			jScript.fullMP = PlayerPrefs.GetInt("MP");
			jScript.currentMP = PlayerPrefs.GetInt("MP");
		}
	}
	
	//Update is called once per frame
	void Update () {
		_player.StatUpdate();

		if(_player.Exp != jScript.currentEXP){
			_player.ExpToLvl = jScript.currentNEXT;
			Debug.Log (_player.ExpToLvl);
			if(addExp){
				_player.AddExp(10);
				addExp = false;
			}
				Debug.Log (_player.Exp);
				_player.CalculateLevel();

				if(_player.LevelUp){
					Debug.Log ("inside levelup if");
					_player.LevelUp = false;
					Debug.Log (_player.LevelUp);
					jScript.currentLV++;;
					jScript.currentEXP = 0;
					jScript.fullHP += jScript.startATK * ( Mathf.CeilToInt(jScript.currentLV / 2));
					jScript.currentHP = jScript.fullHP;
					jScript.fullMP += jScript.startINT * ( Mathf.CeilToInt(jScript.currentLV / 2));
					jScript.currentMP = jScript.fullMP;
					jScript.currentNEXT = (int)(_player.ExpToLvlBase * _player.ExpModifier);
					jScript.levelUpATK += (int)(jScript.startATK * _player.StatModifier);
					jScript.levelUpINT += (int)(jScript.startINT * _player.StatModifier);
					jScript.levelUpAGI += (int)(jScript.startAGI * _player.StatModifier);

					if(jScript.currentLV % 5 == 0)
						jScript.levelUpLCK += 1;

					_player.ExpToLvl = jScript.currentNEXT;
					_player.ExpToLvlBase = _player.ExpToLvl;
				}
		}

		//remove dream special effects once dream sequence is over
		if (PlayerPrefs.GetInt ("Story Progress") >= 9) {
			foreach (GameObject flare in GameObject.FindGameObjectsWithTag("dreamflare")) {
				Destroy (flare);
			}
		}
	}
	
	void SetStats(){

		switch(Progression.playerClass){

		case 1: BaseStat.BaseValue = 10;
			BaseStat.BuffValue = 5;
			jScript.startATK = (int)(_player.GetPrimaryAttribute (0).AdjustedBaseValue * 0.90f);
			jScript.startINT = (int)(_player.GetPrimaryAttribute (1).AdjustedBaseValue * 0.25f);
			jScript.startAGI = (int)(_player.GetPrimaryAttribute (2).AdjustedBaseValue * 0.55f);
			break;
		case 2:	BaseStat.BaseValue = 10;
			BaseStat.BuffValue = 4;
			jScript.startATK = (int)(_player.GetPrimaryAttribute (0).AdjustedBaseValue * 0.70f);
			jScript.startINT = (int)(_player.GetPrimaryAttribute (1).AdjustedBaseValue * 1.25f);
			jScript.startAGI = (int)(_player.GetPrimaryAttribute (2).AdjustedBaseValue * 0.45f);
			break;
		case 3: BaseStat.BaseValue = 10;
			BaseStat.BuffValue = 4;
			jScript.startATK = (int)(_player.GetPrimaryAttribute (0).AdjustedBaseValue * 0.80f);
			jScript.startINT = (int)(_player.GetPrimaryAttribute (1).AdjustedBaseValue * 0.5f);
			jScript.startAGI = (int)(_player.GetPrimaryAttribute (2).AdjustedBaseValue * 2.0f);
			break;
		case 4: BaseStat.BaseValue = 10;
			BaseStat.BuffValue = 4;
			jScript.startATK = (int)(_player.GetPrimaryAttribute (0).AdjustedBaseValue * 0.85f);
			jScript.startINT = (int)(_player.GetPrimaryAttribute (1).AdjustedBaseValue * 0.5f);
			jScript.startAGI = (int)(_player.GetPrimaryAttribute (2).AdjustedBaseValue * 1.45f);
			break;
		}

		if (!PlayerPrefs.HasKey ("Player level")) {
			jScript.currentLV = _player.Level;
			jScript.currentEXP = _player.Exp;
			jScript.currentNEXT = _player.ExpToLvl;
			jScript.startLCK = (int)(_player.GetPrimaryAttribute (3).AdjustedBaseValue * 0.1f);

			jScript.fullHP = (_player.GetVital (0).AdjustedBaseValue * jScript.startATK) + jScript.fullHP;
			jScript.currentHP = jScript.fullHP;
			jScript.fullMP = (_player.GetVital (1).AdjustedBaseValue * jScript.startINT) + jScript.fullMP;
			jScript.currentMP = jScript.fullMP;
		}
	}
}
