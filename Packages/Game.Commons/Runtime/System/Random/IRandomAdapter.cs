using System;

namespace Game.Commons.System.Random
{
	public interface IRandomAdapter
	{
		int Next();
		int Next(int maxValue);
		int Next(int minValue, int maxValue);
		void NextBytes(byte[] buffer);
		void NextBytes(Span<byte> buffer);
		double NextDouble();
		void SetSeed(int seed);
	}
}