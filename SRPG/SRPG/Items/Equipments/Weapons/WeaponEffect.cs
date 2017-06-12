namespace SRPG.Items.Weapons
{
    public class WeaponEffect
    {
        public Unit User { get; set; }

        public void Apply()
        {
            if (User != null)
            {
                User.HP -= 2;
            }
        }
    }
}