namespace probandomapa
{
    public class Moneda : Item,IItem
    {
        public Moneda() 
        {
        }
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("O");
        }

        public void Recoge()
        {
            
        }
    }
    
}