using Coimbra.Services.Events;

namespace _Project.Scripts.Events
{
	public sealed partial class OnChangePlayerState : IEvent
	{
		public PlayerState State;
	}
}