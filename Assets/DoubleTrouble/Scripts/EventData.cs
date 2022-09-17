using EAUnity.Event;

public struct ControlChangeEventData: IGameEventData {
    public CharacterType CharacterType;
    public int PlayerId;
}