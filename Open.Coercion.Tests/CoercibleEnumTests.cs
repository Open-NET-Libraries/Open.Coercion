using Xunit;

namespace Open.Coercion.Tests
{
	public class CoercibleEnumTests
	{
		enum TestEnum
		{
			A,
			B,
			C
		}

		[Fact]
		public void Validate()
		{
			var x = new CoercibleEnum<TestEnum>(TestEnum.A);
			Assert.Equal(TestEnum.A, (TestEnum)x);
			Assert.Equal("A", x);
		}
	}
}
