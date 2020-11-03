using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveStats
{

	private static int score = 0;
	private static int wave = 1;
	private static int enemiesPerWave = 30;

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

	public static int EnemiesPerWave
	{
		get { return enemiesPerWave; }
		set { enemiesPerWave = value; }
	}

	public static void NextWave()
	{
		wave++;
	}

	public static void Reset()
	{
		score = 0;
		wave = 1;
		enemiesPerWave = 30;
	}
	public static void AddToScore()
	{
		score++;
	}

}
