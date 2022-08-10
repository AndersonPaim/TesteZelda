using Coimbra.Services.Events;

namespace _Project.Scripts.Events
{
	public sealed partial class OnUpdateScore : IEvent
	{
		public int Score;
	}
}