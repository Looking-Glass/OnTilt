using UnityEngine;
using System.Collections;

public class Easing : MonoBehaviour {

	/// <summary>
	/// Linear Tween
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float LinearTween (float t, float b, float c, float d){
		return c*t/d + b;
	}

	/// <summary>
	/// Linear Tween Percent
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercLinearTween (float p, float b, float c){
		return c*p + b;
	}

	/// <summary>
	/// Quadratic Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInQuad (float t, float b, float c, float d){
		t /= d;
		return c*t*t + b;
	}

	/// <summary>
	/// Quadratic Ease In Percent
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInQuad (float p, float b, float c){
		return c*p*p + b;
	}

	/// <summary>
	/// Quadratic Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutQuad (float t, float b, float c, float d){
		t /= d;
		return -c * t*(t-2) + b;
	}

	/// <summary>
	/// Quadratic Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutQuad (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return c/2*t*t + b;
		t--;
		return -c/2 * (t*(t-2) - 1) + b;
	}

	/// <summary>
	/// Quadratic Ease In Out Perc
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInOutQuad (float p, float b, float c){
		p *= 2;
		if (p < 1) return c/2*p*p + b;
		p--;
		return -c/2 * (p*(p-2) - 1) + b;
	}

	/// <summary>
	/// Cubic Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInCubic (float t, float b, float c, float d){
		t /= d;
		return c*t*t*t + b;
	}

	/// <summary>
	/// Cubic Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutCubic (float t, float b, float c, float d){
		t /= d;
		t--;
		return c*(t*t*t + 1) + b;
	}

	/// <summary>
	/// Cubic Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutCubic (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return c/2*t*t*t + b;
		t -= 2;
		return c/2*(t*t*t + 2) + b;
	}

	/// <summary>
	/// Quartic Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInQuart (float t, float b, float c, float d){
		t /= d;
		return c*t*t*t*t + b;
	}

	/// <summary>
	/// Quartic Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutQuart (float t, float b, float c, float d){
		t /= d;
		t--;
		return -c * (t*t*t*t - 1) + b;
	}

	/// <summary>
	/// Quartic Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutQuart (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return c/2*t*t*t*t + b;
		t -= 2;
		return -c/2 * (t*t*t*t - 2) + b;
	}

	/// <summary>
	/// Quintic Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInQuint (float t, float b, float c, float d){
		t /= d;
		return c*t*t*t*t*t + b;
	}

	/// <summary>
	/// Quintic Ease In Percent
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInQuint (float p, float b, float c){
		return c*p*p*p*p*p + b;
	}

	/// <summary>
	/// Quintic Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutQuint (float t, float b, float c, float d){
		t /= d;
		t--;
		return c*(t*t*t*t*t + 1) + b;
	}

	/// <summary>
	/// Quintic Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutQuint (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return c/2*t*t*t*t*t + b;
		t -= 2;
		return c/2*(t*t*t*t*t + 2) + b;
	}

	/// <summary>
	/// Sinusoidal Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInSine (float t, float b, float c, float d){
		return -c * Mathf.Cos(t/d * (Mathf.PI/2)) + c + b;
	}

	/// <summary>
	/// Sinusoidal Ease In Perc
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInSine (float p, float b, float c){
		return -c * Mathf.Cos(p * (Mathf.PI/2)) + c + b;
	}

	/// <summary>
	/// Sinusoidal Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutSine (float t, float b, float c, float d){
		return c * Mathf.Sin(t/d * (Mathf.PI/2)) + b;
	}

	/// <summary>
	/// Sinusoidal Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutSine (float t, float b, float c, float d){
		return -c/2 * (Mathf.Cos(Mathf.PI*t/d) - 1) + b;
	}

	/// <summary>
	/// Sinusoidal Ease In Out Perc
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInOutSine (float p, float b, float c){
		return -c/2 * (Mathf.Cos(Mathf.PI*p) - 1) + b;
	}

	/// <summary>
	/// Exponential Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInExpo (float t, float b, float c, float d){
		return c * Mathf.Pow( 2, 10 * (t/d - 1) ) + b;
	}

	/// <summary>
	/// Exponential Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutExpo (float t, float b, float c, float d){
		return c * ( -Mathf.Pow( 2, -10 * t/d ) + 1 ) + b;
	}

	/// <summary>
	/// Exponential Ease Out Percent
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseOutExpo (float p, float b, float c){
		return c * ( -Mathf.Pow( 2, -10 * p ) + 1 ) + b;
	}

	/// <summary>
	/// Exponential Ease In Percent
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInExpo (float p, float b, float c){
		return c * Mathf.Pow( 2, 10 * (p - 1) ) + b;
	}

	/// <summary>
	/// Exponential Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutExpo (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return c/2 * Mathf.Pow( 2, 10 * (t - 1) ) + b;
		t--;
		return c/2 * (-Mathf.Pow( 2, -10 * t) + 2 ) + b;
	}

	/// <summary>
	/// Circular Ease In
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInCirc (float t, float b, float c, float d){
		t /= d;
		return -c * (Mathf.Sqrt(1 - t*t) - 1) + b;
	}

	/// <summary>
	/// Circular Ease Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseOutCirc (float t, float b, float c, float d){
		t /= d;
		t--;
		return c * Mathf.Sqrt(1 - t*t) + b;
	}

	/// <summary>
	/// Circular Ease In Out
	/// </summary>
	/// <returns>float</returns>
	/// <param name="t">time</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	/// <param name="d">duration</param>
	public static float EaseInOutCirc (float t, float b, float c, float d){
		t /= d/2;
		if (t < 1) return -c/2 * (Mathf.Sqrt(1 - t*t) - 1) + b;
		t -= 2;
		return c/2 * (Mathf.Sqrt(1 - t*t) + 1) + b;
	}

	/// <summary>
	/// Circular Ease In Out Perc
	/// </summary>
	/// <returns>float</returns>
	/// <param name="p">percent</param>
	/// <param name="b">start value</param>
	/// <param name="c">change in value</param>
	public static float PercEaseInOutCirc (float p, float b, float c){
		p *= 2;
		if (p < 1) return -c/2 * (Mathf.Sqrt(1 - p*p) - 1) + b;
		p -= 2;
		return c/2 * (Mathf.Sqrt(1 - p*p) + 1) + b;
	}


	public static float EaseInOutBack(float start, float end, float value){
		float s = 1.70158f;
		end -= start;
		value /= .5f;
		if ((value) < 1){
			s *= (1.525f);
			return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
		}
		value -= 2;
		s *= (1.525f);
		return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
	}
}
