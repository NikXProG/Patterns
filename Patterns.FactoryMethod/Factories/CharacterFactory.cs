using Patterns.Core;
using Patterns.Domain.Models;
using Patterns.FactoryMethod.Products;
using Patterns.FactoryMethod.Products.Characters;
using Patterns.FactoryMethod.Products.Characters;

namespace Patterns.FactoryMethod.Factories;

public class WarriorFactory : ICreator<CharacterBase, CharacterModel>, ICreator<CharacterBase>
{
    
    public CharacterBase Create(CharacterModel model)
    {
        return new Warrior(model);
    }
    
    public CharacterBase Create()
    {
        return new Warrior();
    }
    
    
}


public class ArcherFactory : ICreator<CharacterBase, CharacterModel>, ICreator<CharacterBase>
{
    
    public CharacterBase Create(CharacterModel model)
    {
        return new Archer(model);
    }
    
    public CharacterBase Create()
    {
        return new Archer();
    }
    
    
}

public class MageFactory : ICreator<CharacterBase, CharacterModel>, ICreator<CharacterBase>
{
    
    public CharacterBase Create(CharacterModel model)
    {
        return new Mage(model);
    }
    
    public CharacterBase Create()
    {
        return new Mage();
    }
    
    
}