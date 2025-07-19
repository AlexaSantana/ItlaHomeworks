//Alexa Genesis Santana Cabrera 2024-2581
class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }
    public void Mostrar()
    {
        Console.WriteLine($"{Id}    {Nombre}    {Telefono}    {Email}    {Direccion}");
    }
}
class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int proximoId = 1;

    public void Menu()
    {
        bool ejecutando = true;
        while (ejecutando)
        {
            Console.Write("1. Agregar Contacto      ");
            Console.Write("2. Ver Contactos     ");
            Console.Write("3. Buscar Contactos      ");
            Console.Write("4. Modificar Contacto        ");
            Console.Write("5. Eliminar Contacto     ");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1: AgregarContacto(); break;
                case 2: VerContactos(); break;
                case 3: BuscarContacto(); break;
                case 4: ModificarContacto(); break;
                case 5: EliminarContacto(); break;
                case 6: ejecutando = false; break;
                default: Console.WriteLine("Opción no válida"); break;
            }
        }
    }

    public void AgregarContacto()
    {
        Console.WriteLine("Vamos a agregar ese contacte que te trae loco.");
        Console.Write("Digite el Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Digite el Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Digite el Email: ");
        string email = Console.ReadLine();
        Console.Write("Digite la dirección: ");
        string direccion = Console.ReadLine();

        Contacto nuevo = new Contacto(proximoId++, nombre, telefono, email, direccion);
        contactos.Add(nuevo);
        Console.WriteLine();
    }

    public void VerContactos()
    {
        Console.WriteLine("Id           Nombre          Telefono            Email           Dirección");
        Console.WriteLine("___________________________________________________________________________");

        foreach (var c in contactos)
        {
            c.Mostrar();
        }
    }

    public void BuscarContacto()
    {
        VerContactos();
        Console.WriteLine("Digite un Id de Contacto Para Mostrar");
        int id = Convert.ToInt32(Console.ReadLine());
        var c = contactos.Find(x => x.Id == id);

        if (c != null)
        {
            Console.WriteLine($"El nombre es: {c.Nombre}");
            Console.WriteLine($"El Teléfono es: {c.Telefono}");
            Console.WriteLine($"El Email es: {c.Email}");
            Console.WriteLine($"La dirección es: {c.Direccion}");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void ModificarContacto()
    {
        VerContactos();
        Console.WriteLine("Digite un Id de Contacto Para Editar");
        int id = Convert.ToInt32(Console.ReadLine());
        var c = contactos.Find(x => x.Id == id);

        if (c != null)
        {
            Console.Write($"El nombre es: {c.Nombre}, Digite el Nuevo Nombre: ");
            c.Nombre = Console.ReadLine();

            Console.Write($"El Teléfono es: {c.Telefono}, Digite el Nuevo Teléfono: ");
            c.Telefono = Console.ReadLine();

            Console.Write($"El Email es: {c.Email}, Digite el Nuevo Email: ");
            c.Email = Console.ReadLine();

            Console.Write($"La dirección es: {c.Direccion}, Digite la nueva dirección: ");
            c.Direccion = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void EliminarContacto()
    {
        VerContactos();
        Console.WriteLine("Digite un Id de Contacto Para Eliminar");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("¿Seguro que desea eliminar? 1. Sí, 2. No");
        int confirm = Convert.ToInt32(Console.ReadLine());

        if (confirm == 1)
        {
            var c = contactos.Find(x => x.Id == id);
            if (c != null)
            {
                contactos.Remove(c);
                Console.WriteLine("Contacto eliminado.");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactes");
        Agenda agenda = new Agenda();
        agenda.Menu();
    }
}