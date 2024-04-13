

namespace API;

public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetAnimal(int id);
    public void AddAnimal(Animal animal);
    public void EditAnimal(int id, Animal animal);
    public void DeleteAnimal(Animal animal);
    public void AddVisit(Visit visit);
    public  ICollection<Visit> GetAllVisits();
}

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;
    private ICollection<Visit> _visits;

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
        var toDelete = _animals.FirstOrDefault(animal => animal.ID == id);
        _animals.Remove(toDelete);
        _animals.Add(added);
        
    }

    public void DeleteAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }

    public ICollection<Visit> GetAllVisits()
    {
        return _visits;
    }
}