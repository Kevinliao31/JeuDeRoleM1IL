using ProjetJeuDeRole_M1IL.Personnages;

internal class Program
{
    private static void Main(string[] args)
    {
        Personnage personnage = new("Kelio", 70, 70, 100, 200, 200, 50, 50);
        personnage.AfficherStatut();
    }
}