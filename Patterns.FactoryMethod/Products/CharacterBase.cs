using System.Runtime.InteropServices.JavaScript;
using Patterns.Core.Interfaces;
using Patterns.Domain.Models;
using Serilog.Core;

namespace Patterns.FactoryMethod.Products;

public abstract class CharacterBase : ICloneable
{

    #region Fields

    private int _health;
    private string? _name;

    #endregion

    #region Constructors
    protected CharacterBase(CharacterModel model)
    {
        Name = model.Name ?? throw new ArgumentNullException(nameof(model.Name));
        Health = model.Health < 0 ? 0 : model.Health;
    }

    protected CharacterBase() { Name = "None"; }

    #endregion
    
    #region Properties

    public int Health
    {
        
        get=>_health;
        
        set => _health = value;
        
    }
    
    public string? Name
    {
        
        get=>_name;
        
        set => _name = value;
        
    }

    #endregion
    
    #region Methods
    public abstract void Attack();
    
    public object Clone()
    {
        var clone = (CharacterBase)this.MemberwiseClone();
        HandleCloned(clone);
        return clone;
    }
    
    protected virtual void HandleCloned(CharacterBase clone)
    {
        //Nothing particular in the base class, but maybe useful for children.
        //Not abstract so children may not implement this if they don't need to.
    }
    
    
    public override string ToString()
    {
        return $"{nameof(Health)}: {Health}; "
               + $"{nameof(Name)}: {Name}; ";
    }
    
    #endregion
    

}