using System;

namespace Game.Commons.System.Random
{
	public class RandomAdapterAdapter : IRandomAdapter
	{
		private global::System.Random _random;

		public RandomAdapterAdapter()
			=> _random = new global::System.Random();

		public void SetSeed(int seed)
			=> _random = new global::System.Random(seed);

		public int Next()
			=> _random.Next();

		public int Next(int maxValue)
			=> _random.Next(maxValue);

		public int Next(int minValue, int maxValue)
			=> _random.Next(minValue, maxValue);

		public void NextBytes(byte[] buffer)
			=> _random.NextBytes(buffer);

		public void NextBytes(Span<byte> buffer)
			=> _random.NextBytes(buffer);

		public double NextDouble()
			=> _random.NextDouble();
	}
}