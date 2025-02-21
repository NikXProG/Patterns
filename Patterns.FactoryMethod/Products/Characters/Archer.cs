using Patterns.Core.Interfaces;
using Patterns.Domain.Models;

namespace Patterns.FactoryMethod.Products.Characters;

public class Archer : CharacterBase
{
    
    #region Constructors

    public Archer(CharacterModel model) : base(model) { }
    
    public Archer() : base() { }

    #endregion
    
    
    #region Properties

    public int Damage
    {
        get;

        set; 
    }
    
    public double RadiusBow
    {
        get;

        set; 
    }
    
    
    #endregion
    
    #region Methods

    public override void Attack()
    {
        
    }

    protected override void HandleCloned(CharacterBase clone)
    {
        base.HandleCloned(clone);
        
        Archer obj = (Archer) clone;
        
        obj.Damage = 20;

        obj.RadiusBow = 55.5;
        
    }

    public override string ToString()
    {

        return $"{nameof(Damage)}: {Damage}; " +
               $"{nameof(RadiusBow)}: {RadiusBow}; " +
               base.ToString();
    }
    
    #endregion

    ~Archer()
    {
        Console.WriteLine("Archer has been destroyed");
    }
    
}