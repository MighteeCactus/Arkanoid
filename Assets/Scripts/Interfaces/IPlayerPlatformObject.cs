namespace Arkanoid
{
    public interface IPlayerPlatformObject : IImpact
    {
        IPlayerPlatformView View { get; }
    }
}