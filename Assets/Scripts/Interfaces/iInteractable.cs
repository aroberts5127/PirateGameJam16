/// <summary>
/// This goes on gameObjects that can be interacted with. 
/// Possessable Items Interact will be to Possess.
/// Things like signs it will be to read the sign.
/// </summary>
public interface iInteractable
{
    void Interact();
    void Interact(PlayerState_Player interacter);
}