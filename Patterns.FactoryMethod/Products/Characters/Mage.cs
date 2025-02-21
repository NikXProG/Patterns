using Patterns.FactoryMethod.Products;
using Patterns.Domain.Models;

namespace Patterns.FactoryMethod.Products.Characters;

public class Mage : CharacterBase
{
    #region Constructors

    public Mage(CharacterModel model) : base(model) { }
    
    public Mage() : base() { }

    #endregion
    
    #region Properties

    public int Hill
    {
        get;

        set; 
    }
    
    #endregion
    
    #region Methods
    
    public override void Attack() => Console.WriteLine("Mage attacks!");
    
    protected override void HandleCloned(CharacterBase clone)
    {
        base.HandleCloned(clone);
        
        Mage obj = (Mage) clone;
        
        obj.Hill = 40;
        
        
    }

    public override string ToString()
    {

        return $"{nameof(Hill)}: {Hill}; " +
               base.ToString();
    }

    #endregion

    
}