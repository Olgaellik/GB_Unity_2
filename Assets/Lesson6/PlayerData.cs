using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
	public string Name;
	public float HP;
	public bool IsVisible;

	public override string ToString()
	{
		return $"Name: {Name} HP: {HP} IsVisible: {IsVisible}";
	}

	public void CopyFrom(PlayerData d)
	{
		Name = d.Name;
		HP = d.HP;
		IsVisible = d.IsVisible;
		
	}
}