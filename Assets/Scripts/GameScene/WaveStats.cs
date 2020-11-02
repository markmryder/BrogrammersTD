using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveStats
{

	private static int score = 0;
	private static int wave = 1;
	private static int enemiesRemaining = 30;

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

	public static int EnemiesRemaining
	{
		get { return enemiesRemaining; }
		set { enemiesRemaining = value; }
	}

	public static void NextWave()
	{
		wave++;
	}

	public static void RemoveEnemeyFromCount() 
	{
		enemiesRemaining--;
	}

	public static void Reset()
	{
		score = 0;
		wave = 1;
		enemiesRemaining = 30;
	}

}
