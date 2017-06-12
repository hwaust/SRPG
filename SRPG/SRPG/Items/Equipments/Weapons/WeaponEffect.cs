namespace SRPG.Items.Weapons
{
    public class WeaponEffect
    {
        public Person User { get; set; }

        public void Apply()
        {
            if (User != null)
            {
                User.HP -= 2;
            }
        }
    }
}