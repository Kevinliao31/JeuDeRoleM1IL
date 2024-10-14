using ProjetJeuDeRole_M1IL.Personnages;

namespace ProjetJeuDeRole_M1IL.Combat
{
    public class Combat
    {
        private readonly List<Personnage> personnages;
        private int compteurRound = 1;

        public Combat(List<Personnage> personnages)
        {
            this.personnages = personnages;
        }

        public void LancerCombat()
        {
            // Continue le combat tant qu'il y a plus d'un personnage en vie
            while (personnages.Count(p => p.EstVivant()) > 1)
            {
                if (!PoursuivreOuQuitterCombat())
                {
                    return;
                }

                // Réinitialisation des attaques pour chaque personnage
                foreach (Personnage personnage in personnages)
                {
                    personnage.AfficherStatut();
                    personnage.ResetAttaques();
                }

                List<Personnage> ordreInitiative = LancerRound();

                // Faire attaquer les personnages en fonction de l'initiative de chacun
                foreach (Personnage attaquant in ordreInitiative)
                {
                    if (attaquant.EstVivant())
                    {
                        Console.WriteLine($"{attaquant.Name} prend son tour !");

                        // Choisir une cible parmi les personnages vivants
                        Personnage cible = ChoisirCible(attaquant);
                        attaquant.Attaquer(cible);
                    }
                }
            }

            AfficherGagnant();
        }

        // Afficher le gagnant
        private void AfficherGagnant()
        {
            Personnage? gagnant = personnages.FirstOrDefault(p => p.EstVivant());
            if (gagnant != null)
            {
                Console.WriteLine($"\nLe combat est terminé ! Le gagnant est {gagnant.Name}.");
            }
            else
            {
                Console.WriteLine("Le combat est terminé, aucun gagnant !");
            }
        }

        // Si une autre touche que x est appuyée, retourne true pour continuer le combat, false sinon
        private bool PoursuivreOuQuitterCombat()
        {
            Console.WriteLine("\nAppuyez sur une touche pour continuer le combat et passer au prochain round (x pour quitter)");
            ConsoleKey touche = Console.ReadKey().Key;

            if (touche == ConsoleKey.X)
            {
                Console.WriteLine("\nLe combat a été interrompu par l'utilisateur, il n'y a donc pas de vainqueur.");
                return false;
            }

            return true;
        }

        // Lancer un nouveau round et obtenir l'initiative des différents personnages
        public List<Personnage> LancerRound()
        {
            Console.WriteLine($"\nRound n°{compteurRound} : \n");

            Dictionary<Personnage, int> initiatives = [];

            // Calcul des initiatives pour chaque personnage
            foreach (Personnage personnage in personnages)
            {
                int jetInitiative = personnage.JetInitiative();
                initiatives[personnage] = jetInitiative;

                Console.WriteLine($"{personnage.Name} a une initiative de {jetInitiative}");
            }

            compteurRound++;

            return personnages;
        }

        // Méthode pour choisir la cible au hasard
        private Personnage ChoisirCible(Personnage attaquant)
        {
            if (personnages.Count <= 1)
            {
                throw new InvalidOperationException("Il n'y a pas assez de personnages pour choisir une cible.");
            }

            Random rnd = new();
            Personnage cible;
            do
            {
                cible = personnages[rnd.Next(personnages.Count)];
            } while (cible == attaquant);
            return cible;
        }
    }
}
