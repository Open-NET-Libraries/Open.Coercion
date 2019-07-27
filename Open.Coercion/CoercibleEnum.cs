using System;
using System.Collections.Generic;

namespace Open.Coercion
{
	public struct CoercibleEnum<T>
		where T : struct, Enum
	{
		public T Value { get; }
		public CoercibleEnum(T value)
		{
			Value = value;
		}

		public static implicit operator T(CoercibleEnum<T> value)
			=> value.Value;

		public static implicit operator CoercibleEnum<T>(T value)
			=> new CoercibleEnum<T>(value);

		public static bool operator ==(CoercibleEnum<T> a, CoercibleEnum<T> b)
			=> a.Value.Equals(b.Value);

		public static bool operator !=(CoercibleEnum<T> a, CoercibleEnum<T> b)
			=> !a.Value.Equals(b.Value);

		public static bool operator ==(CoercibleEnum<T> a, T b)
			=> a.Value.Equals(b);

		public static bool operator !=(CoercibleEnum<T> a, T b)
			=> !a.Value.Equals(b);

		public static bool operator ==(T a, CoercibleEnum<T> b)
			=> b.Value.Equals(a);

		public static bool operator !=(T a, CoercibleEnum<T> b)
			=> !b.Value.Equals(a);

		public bool Equals(Coercible<T> other)
			=> Value.Equals(other.Value);

		public override bool Equals(object other)
			=> other is CoercibleEnum<T> value && Equals(value);

		public override int GetHashCode()
			=> -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);

		public override string ToString()
			=> Value.ToString();

		public static implicit operator string(CoercibleEnum<T> value)
			=> value.Value.ToString();

		public static implicit operator CoercibleEnum<T>(string value)
			=> Enum.TryParse<T>(value, true, out var coercible) ? coercible
			 : throw new ArgumentOutOfRangeException(nameof(value), value, "Must be a value of type: " + typeof(T));
	}
}
