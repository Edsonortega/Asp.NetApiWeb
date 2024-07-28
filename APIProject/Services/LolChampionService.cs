using APIProject.Models;

namespace APIProject.Services;

public static class LolChampionService
{
    // Propiedad estática que almacena la lista de campeones
    static List<LolChampion> Champions { get; }
    
    // Variable estática para asignar el siguiente ID disponible
    static int nextId = 3;
    
    // Constructor estático para inicializar la lista de campeones
    static LolChampionService()
    {
        Champions = new List<LolChampion>
        {
            new LolChampion { Id = 1, Name = "Jinx", RolChampion = "ADC" },
            new LolChampion { Id = 2, Name = "Jhin", RolChampion = "ADC" }
        };
    }

    // Método para obtener todos los campeones
    public static List<LolChampion> GetAll() => Champions;

    // Método para obtener un campeón por su ID
    public static LolChampion? Get(int id) => Champions.FirstOrDefault(p => p.Id == id);

    // Método para añadir un nuevo campeón a la lista
    public static void Add(LolChampion champion)
    {
        champion.Id = nextId;
        nextId++;
        Champions.Add(champion);
    }

    // Método para eliminar un campeón por su ID
    public static void Delete(int id)
    {
        var champion = Get(id);
        if (champion is null)
        {
            return;
        }
        Champions.Remove(champion);
    }

    // Método para actualizar un campeón existente
    public static void Update(LolChampion champion)
    {
        var index = Champions.FindIndex(p => p.Id == champion.Id);
        if (index == -1)
        {
            return;
        }
        Champions[index] = champion;
    }
}
