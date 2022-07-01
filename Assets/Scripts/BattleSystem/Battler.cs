namespace turganaliyev.BattleSystem
{
    [System.Serializable]
    public class Battler
    {
        public Team Team;
        public Weapons Weapon;

        public float Damage;
        public float DamageReload;

        public bool IsPlayer;

        public Battler(Team team, Weapons weapon, float damage, float damageReload, bool isPlayer)
        {
            Team = team;
            Weapon = weapon;
            Damage = damage;
            DamageReload = damageReload;

            IsPlayer = isPlayer;
        }
    }
}