public class BaseStat {
	private static int baseValue;  					//base value for the stat
	private static int buffValue;						//how much the value affects combat info


	public BaseStat(){
		baseValue = 10;
		buffValue = 5;

	}
	
	public static int BaseValue {
		get{ return baseValue;}
		set{ baseValue = value;}
		}

	public static int BuffValue {
		get{ return buffValue;}
		set{ buffValue = value;}
		}

	public int AdjustedBaseValue{
		get{return baseValue + buffValue;}
	}
}
