namespace PokeConnection.External.Responses;

public class EvolutionChainResponse
{
    public int id { get; set; }
    public Item baby_trigger_item { get; set; } 
    public Chain chain { get; set; }
}

public class Chain
{
    public bool is_baby { get; set; }
    public Species species { get; set; }
    public List<EvolutionDetail> evolution_details { get; set; } 
    public List<EvolvesToPokemon> evolves_to { get; set; }
}

public class EvolutionDetail
{
    public Item item { get; set; }
    public Trigger trigger { get; set; }
    public int? gender { get; set; }  
    public Item held_item { get; set; }
    public Move known_move { get; set; }
    public Type known_move_type { get; set; }
    public Location location { get; set; }
    public int? min_level { get; set; }  
    public int? min_happiness { get; set; }  
    public int? min_beauty { get; set; }  
    public int? min_affection { get; set; }  
    public bool needs_overworld_rain { get; set; }
    public Species party_species { get; set; }
    public Type party_type { get; set; }
    public int? relative_physical_stats { get; set; }  
    public string time_of_day { get; set; }
    public Species trade_species { get; set; }
    public bool turn_upside_down { get; set; }
}

public class EvolvesToPokemon
{
    public bool is_baby { get; set; }
    public Species species { get; set; }
    public List<EvolutionDetail> evolution_details { get; set; }
    public List<EvolvesToPokemon>? evolves_to { get; set; } 
}

public class Trigger
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Location
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Species
{
    public string name { get; set; }
    public string url { get; set; }
}
