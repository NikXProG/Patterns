using Patterns.Domain.Models;

namespace Patterns.FactoryMethod.Products.Characters;

public class Warrior : CharacterBase
{
    #region Constructors
    
    public Warrior() {}
    public Warrior(CharacterModel model) : base(model) { }
    
    #endregion
    
    #region Methods
    
    public override void Attack() => Console.WriteLine("Warrior attacks!");
    
    
    #endregion

}