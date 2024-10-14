using ProjetJeuDeRole_M1IL.Combat;
using ProjetJeuDeRole_M1IL.Personnages;

internal class Program
{
    private static void Main(string[] args)
    {
        Guerrier guerrier = new("Hector");
        Guerrier guerrier2 = new("Simon");

        List<Personnage> combattants = [guerrier, guerrier2];

        Combat duel = new(combattants);
        duel.LancerCombat();

        Console.WriteLine("Fin du combat.");
    }
}