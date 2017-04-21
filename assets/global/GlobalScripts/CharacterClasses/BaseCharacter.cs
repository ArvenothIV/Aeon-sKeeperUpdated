using UnityEngine;
using System.Collections;
using System;									//access enum class

public class BaseCharacter : MonoBehaviour {
	private int _level;
	private int _exp;
	private int _expToLvl;
	private int _expToLvlBase;
	private float _expModifier;
	private bool _levelUp;
	private float _hpMod;
	private float _mpMod;
	private float _statModifier;

	private Attribute[] primaryAttribute;
	private Vital[] vital;
	//private Skill[] skill;

	public void Awake(){
		_level = 1;
		_expToLvl = 100;
		_expToLvlBase = 100;
		_expModifier = 1.1f;
		_exp = 0;
		_hpMod = 1.0f;
		_mpMod = 1.0f;
		_statModifier = 0.25f;
		_levelUp = false;

		primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
//		skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes();
		SetupVitals();

	}
	public float StatModifier{
		get{ return _statModifier;}
		set{ _statModifier = value;}
	}
	public int Level{
		get{return _level;}
		set{_level = value;}
	}

	public int Exp{
		get{return _exp;}
		set{_exp = value;}
	}

	public int ExpToLvl{
		get{return _expToLvl;}
		set{_expToLvl = value;}
	}

	public int ExpToLvlBase{
		get{return _expToLvlBase;}
		set{_expToLvlBase = value;}
	}

	public void AddExp(int exp){
		_exp += exp;
	}

	public float ExpModifier{
		get{ return _expModifier;}
		set{ _expModifier = value;}
	}

	public bool LevelUp{
		get{return _levelUp;}
		set{_levelUp = value;}
	}

	public float HpMod {
		get{ return _hpMod;}
		set{ _hpMod = value;}
	}

	public float MpMod {
		get{ return _mpMod;}
		set{ _mpMod = value;}
	}
	
	public void CalculateLevel(){
		Debug.Log ("inside calculate level");
		if(_expToLvl <= 0){
			_levelUp = true;													//if acquired exp is greater than or equal to required exp to lvl, increase lvl, increase exp to lvl and reset acquired exp
			Debug.Log ("leveled up");
			_expToLvl = (int)(_expToLvlBase * 1.1f);
		}
	}

	private void SetupPrimaryAttributes(){
		for(int cnt = 0; cnt < primaryAttribute.Length; cnt++){
			primaryAttribute[cnt] = new Attribute();
		}
	}

	public void SetupVitals(){
		for(int cnt = 0; cnt < vital.Length; cnt++){
			vital[cnt] = new Vital();
		}

		SetupVitalModifiers();
	}


	public Attribute GetPrimaryAttribute(int index){
		return primaryAttribute[index];
	}

	public Vital GetVital(int index){
		return vital[index];
	}

//	public Skill GetSkill(int index){
//		return skill[index];
//	}

	private void SetupVitalModifiers(){
		//health
		GetVital((int)VitalName.Health).AddModifer(new ModifyingStats(GetPrimaryAttribute((int)AttributeName.Strength), _hpMod));
		//MP or energy whatever we call it
		GetVital((int)VitalName.Mana).AddModifer(new ModifyingStats(GetPrimaryAttribute((int)AttributeName.Intelligence), _mpMod));
	}


	public void StatUpdate(){
		for(int cnt = 0; cnt < vital.Length; cnt++){
			vital[cnt].Update();
		}
	}
}
