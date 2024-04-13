using System.Collections.Generic;
using System.Linq;

namespace API;

public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetAnimal(int id);
    public void AddAnimal(Animal animal);
    public void EditAnimal(int id, Animal animal);
}

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;

    public MockDb()
    {
        _animals = new List<Animal>
        {
            new Animal
            {
                ID = 1,
                Kategoria = "Pies",
                Imie = "Kuba",
                KolorSiersci = "bialy",
                Waga = 40
            }
        };
    }

    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public Animal? GetAnimal(int id)
    {
        return _animals.FirstOrDefault(animal => animal.ID==id);
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void EditAnimal(int id,Animal added)
    {
        _animals.Remove(_animals.FirstOrDefault(animal => animal.ID == id));
        _animals.Add(added);
        
    }
}