using Coimbra.Services.Events;

namespace _Project.Scripts.Events
{
	public sealed partial class OnCollectGem : IEvent
	{
		public int Score;
	}
}