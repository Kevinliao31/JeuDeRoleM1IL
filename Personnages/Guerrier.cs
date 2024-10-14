namespace ProjetJeuDeRole_M1IL.Personnages
{
    public class Guerrier : Personnage
    {
        // Caractéristiques de base
        public Guerrier(string name) : base(name, 100, 100, 50, 100, 200, 200, 2, 2) { }

        public override void RecevoirDegats(int degats)
        {
            base.RecevoirDegats(degats);
            // Le Guerrier est affecté par la douleur mais seulement pour le round en cours
            Console.WriteLine($"{Name} est affecté par la douleur, il ne peut pas attaquer pendant ce round.");
            CurrentAttackNumber = 0; // Perd toutes ses attaques pour ce round
        }
    }
}
