//Alexa Genesis Santana Cabrera 2024-2581
class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a mi lista de Contactes");

        bool runing = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (runing)
        {
            Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
            Console.WriteLine("Digite el número de la opción deseada");

            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 2:
                    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                    Console.WriteLine($"____________________________________________________________________________________________________________________________");
                    foreach (var id in ids)
                    {
                        var isBestFriend = bestFriends[id];
                        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                    }
                    break;

                case 3: // Buscar contacto
                    Console.WriteLine("Ingrese el nombre o apellido a buscar:");
                    string search = Console.ReadLine().ToLower();
                    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                    Console.WriteLine($"____________________________________________________________________________________________________________________________");
                    foreach (var id in ids)
                    {
                        if (names[id].ToLower().Contains(search) || lastnames[id].ToLower().Contains(search))
                        {
                            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
                            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                        }
                    }
                    break;

                case 4: // Modificar contacto
                    Console.WriteLine("Ingrese el ID del contacto a modificar:");
                    int modId = Convert.ToInt32(Console.ReadLine());
                    if (ids.Contains(modId))
                    {
                        Console.WriteLine("Nuevo nombre:");
                        names[modId] = Console.ReadLine();

                        Console.WriteLine("Nuevo apellido:");
                        lastnames[modId] = Console.ReadLine();

                        Console.WriteLine("Nueva dirección:");
                        addresses[modId] = Console.ReadLine();

                        Console.WriteLine("Nuevo teléfono:");
                        telephones[modId] = Console.ReadLine();

                        Console.WriteLine("Nuevo email:");
                        emails[modId] = Console.ReadLine();

                        Console.WriteLine("Nueva edad:");
                        ages[modId] = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("¿Es mejor amigo? 1. Si, 2. No");
                        bestFriends[modId] = Convert.ToInt32(Console.ReadLine()) == 1;

                        Console.WriteLine("¡Contacto modificado exitosamente!");
                    }
                    else
                    {
                        Console.WriteLine("ID no encontrado.");
                    }
                    break;

                case 5: // Eliminar contacto
                    Console.WriteLine("Ingrese el ID del contacto a eliminar: ");
                    int delId = Convert.ToInt32(Console.ReadLine());
                    if (ids.Contains(delId))
                    {
                        ids.Remove(delId);
                        names.Remove(delId);
                        lastnames.Remove(delId);
                        addresses.Remove(delId);
                        telephones.Remove(delId);
                        emails.Remove(delId);
                        ages.Remove(delId);
                        bestFriends.Remove(delId);

                        Console.WriteLine("¡Contacto eliminado exitosamente!");
                    }
                    else
                    {
                        Console.WriteLine("ID no encontrado.");
                    }
                    break;

                case 6:
                    runing = false;
                    break;

                default:
                    Console.WriteLine("Tu eres o te haces el idiota?");
                    break;
            }
        }
    }

    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
    }
}