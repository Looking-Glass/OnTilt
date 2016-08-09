using UnityEngine;
using System.Collections;

public class GeneralUtil 
{
	/// <summary>
	/// Ranges to percent. Unclamped
	/// </summary>
	/// <returns>Percent as decimal</returns>
	/// <param name="number">Number.</param>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	public static float RangeToPercent (float number,float  min, float max)
	{
		return ((number - min) / (max - min));
	}

	/// <summary>
	/// Ranges to percent. Clamped
	/// </summary>
	/// <returns>Percent as decimal</returns>
	/// <param name="number">Number.</param>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	public static float RangeToPercentClamp (float number,float  min, float max)
	{
		float result = ((number - min) / (max - min));
		if (result > 1)
		{
			result = 1;
		}
		else if (result < 0)
		{
			result = 0;
		}

		return result;
	}

	/// <summary>
	/// Percents to range. Unclamped
	/// </summary>
	/// <returns>The value of a percent of a range.</returns>
	/// <param name="percent">Percent as decimal</param>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	public static float PercentToRange (float percent, float min, float max)
	{
		return ((max - min) * percent + min);
	}

	/// <summary>
	/// Percents to range. Clamped
	/// </summary>
	/// <returns>The value of a percent of a range.</returns>
	/// <param name="percent">Percent as decimal</param>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	public static float PercentToRangeClamp (float percent, float min, float max)
	{
		float result = ((max - min) * percent + min);

		if (result > max)
		{
			result = max;
		}
		else if (result < min)
		{
			result = min;
		}
			
		return result;
	}


	/// <summary>
	/// Determines if is a is approximately equal to b using the specified tolerance.
	/// </summary>
	/// <returns><c>true</c> if a is approximately equal to b using the specified tolerance; otherwise, <c>false</c>.</returns>
	/// <param name="a">Number.</param>
	/// <param name="b">Number.</param>
	/// <param name="Tolerance">Tolerance.</param>
	public static bool IsApproximatelyEqual (float a, float b, float tolerance)
	{
		return (Mathf.Abs(a - b) < tolerance);
	}

	public static Vector3 CloneVector3 (Vector3 v)
	{
		return new Vector3(v.x, v.y, v.z);
	}

	public static Vector2 CloneVector2 (Vector2 v)
	{
		return new Vector2(v.x, v.y);
	}

	public static Vector3 RandomUnitVector3 ()
	{
		return new Vector3 (Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
	}

	public static Vector2 RandomUnitVector2 ()
	{
		return new Vector2 (Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
	}

	public static void PrefSetBool(string name, bool booleanValue) 
	{
		PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
	}

	public static bool PrefGetBool(string name)  
	{
		return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}

	public static bool PrefGetBool(string name, bool defaultValue)
	{
		if(PlayerPrefs.HasKey(name)) 
		{
			return PrefGetBool(name);
		}
		else
		{
			PrefSetBool(name, defaultValue);
		}
		return defaultValue;
	}


}
