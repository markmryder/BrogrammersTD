using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveStats
{

	private static int score = 0;
	private static int wave = 1;

	public static int Score 
	{
		get { return score; } 
		set { score = value; } 
	}

	public static int Wave
	{
		get { return wave; }
		set { wave = value; }
	}

	public static void NextWave()
	{
		wave++;
	}

}
