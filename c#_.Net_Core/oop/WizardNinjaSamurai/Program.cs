using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja shadow = new Ninja("Shadow");
            Samurai speedy = new Samurai("Speedy");
            Wizard harry = new Wizard("Harry");

            shadow.Attack(speedy);
            speedy.Attack(shadow);
            speedy.Attack(harry);
            harry.Attack(shadow);
            harry.Heal(shadow);
            shadow.Steal(speedy);
            speedy.Meditate();
        }
    }
}
