namespace ProjetJeuDeRole_M1IL.Personnages
{
    public class Personnage
    {
        #region Propriété publiques
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
        public Personnage(string name, int attack, int defense, int initiative, int maximumLife, int currentLife, int totalAttackNumber, int currentAttackNumber)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            Initiative = initiative;
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

        public int JetInitiative()
        {
            Random rnd = new();
            return Initiative + rnd.Next(1, 101);
        }

        public int JetDefense()
        {
            Random rnd = new();
            return Defense + rnd.Next(1, 101);
        }

        public int JetAttack()
        {
            Random rnd = new();
            return Attack + rnd.Next(1, 101);
        }

        public void AfficherStatut()
        {
            Console.WriteLine($"{Name} - Vie: {CurrentLife}/{MaximumLife}, Attaques restantes: {CurrentAttackNumber}");
        }
        #endregion
    }
}
