using EAUnity.Event;

public struct ControlChangeEventData: IGameEventData {
    public CharacterType CharacterType;
    public PlayerInfo PlayerInfo;
}