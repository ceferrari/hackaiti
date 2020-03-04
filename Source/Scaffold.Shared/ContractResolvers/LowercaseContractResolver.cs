using Newtonsoft.Json.Serialization;

namespace Scaffold.Shared.ContractResolvers
{
	public class LowercaseContractResolver : DefaultContractResolver
	{
		protected override string ResolvePropertyName(string propertyName)
		{
			return propertyName.ToLower();
		}
	}
}
