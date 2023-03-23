using UnityEngine;

namespace OriOpaStudio.Utilities
{
	public static class RNG
	{
		private static RNG()
		{
			Random.InitState(Random.Range(Random.Range(Random.Range(Random.Range(0, 25), Random.Range(324, 5673)), Random.Range(Random.Range(53, 2378), Random.Range(50, 423))), Random.Range(Random.Range(Random.Range(23, 2354), Random.Range(1, 3456)), Random.Range(Random.Range(7, 32421), Random.Range(8, 23472)))));
		}

		public static int GetRandomIntBetween(int fromInclusive, int toInclusive)
		{
			return Random.Range(fromInclusive, toInclusive);
		}
	}
}