using System.Collections.Generic;

namespace Open.Coercion
{
	public class Coercible<T>
		where T : struct
	{
		public T Value { get; }
		public Coercible(T value)
		{
			Value = value;
			Registry.Add(value, this);
		}

		protected static readonly SortedDictionary<T, Coercible<T>> Registry
			= new SortedDictionary<T, Coercible<T>>();

		public static implicit operator T(Coercible<T> value)
			=> value.Value;

		public static implicit operator Coercible<T>(T value)
			=> Registry[value];
	}
}
