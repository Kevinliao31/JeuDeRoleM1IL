namespace ProjetJeuDeRole_M1IL.Personnages
{
    public abstract class Personnage
    {
        #region Propriétés publiques
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Initiative { get; set; }
        public int Damages { get; set; }
        public int MaximumLife { get; set; }
        public int CurrentLife { get; set; }
        public int TotalAttackNumber { get; set; }
        public int CurrentAttackNumber { get; set; }
        #endregion

        #region Constructeur
        public Personnage(string name, int attack, int defense, int initiative, int damages, int maximumLife, int currentLife, int totalAttackNumber, int currentAttackNumber)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            Initiative = initiative;
            Damages = damages;
            MaximumLife = maximumLife;
            CurrentLife = currentLife;
            TotalAttackNumber = totalAttackNumber;
            CurrentAttackNumber = currentAttackNumber;
        }
        #endregion

        #region Méthodes
        // Méthode pour savoir si le personnage est en vie
        public bool EstVivant()
        {
            return CurrentLife > 0;
        }

        public virtual void RecevoirDegats(int degats)
        {
            CurrentLife -= degats;
            if (CurrentLife < 0) CurrentLife = 0;
        }

        public virtual void ResetAttaques()
        {
            CurrentAttackNumber = TotalAttackNumber;
        }

        public virtual int JetInitiative()
        {
            Random rnd = new();
            return Initiative + rnd.Next(1, 101);
        }

        public virtual int JetDefense()
        {
            Random rnd = new();
            return Defense + rnd.Next(1, 101);
        }

        public virtual int JetAttack()
        {
            Random rnd = new();
            return Attack + rnd.Next(1, 101);
        }

        // Méthode pour attaquer et réduire la vie de la cible
        public void Attaquer(Personnage cible)
        {
            Random rnd = new();

            int jetAttaque = this.Attack + rnd.Next(1, 101);
            Console.WriteLine($"{this.Name} lance une attaque avec un jet d'attaque de {jetAttaque}.");

            int jetDefense = cible.Defense + rnd.Next(1, 101);
            Console.WriteLine($"{cible.Name} se défend avec un jet de défense de {jetDefense}.");

            int margeAttaque = jetAttaque - jetDefense;

            // Si la marge d'attaque est positive, l'attaque est réussie
            if (margeAttaque > 0)
            {
                int degats = (margeAttaque * this.Damages) / 100;

                cible.CurrentLife -= degats;

                Console.WriteLine($"{this.Name} inflige {degats} points de dégâts à {cible.Name}.");

                if (!cible.EstVivant())
                {
                    Console.WriteLine($"{cible.Name} est mort !");
                }
            }
            else
            {
                // L'attaque a échoué, possibilité de contre-attaque si la cible est éligible
                Console.WriteLine($"{this.Name} a échoué à frapper {cible.Name}.");
            }
        }

        public void AfficherStatut()
        {
            Console.WriteLine($"{Name} - Vie: {CurrentLife}/{MaximumLife}, Attaques restantes: {CurrentAttackNumber}");
        }
        #endregion
    }
}
