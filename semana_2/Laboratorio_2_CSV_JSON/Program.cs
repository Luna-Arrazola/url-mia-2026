using System.Text.Json;

string archivoCsv = "estudiantes.csv"; // Es el nombre del archivo csv

List<Estudiante> estudiantes = new List<Estudiante>(); // Aquí se hace una lista en donde se van a almacenar los estudiantes que se ingresen

string[] lineas = File.ReadAllLines(archivoCsv); // Se leen todas las líneas del archivo

for (int i = 1; i < lineas.Length; i++) // En este for se recorre el archivo omitiendo el encabezado
{
    string[] datos = lineas[i].Split(','); // Separa cada línea por comas

    Estudiante estudiante = new Estudiante() // Crea un objeto Estudiante
    {
        Id = int.Parse(datos[0]),
        Nombre = datos[1],
        Carrera = datos[2]
    };

    estudiantes.Add(estudiante); // Lo agrega a la lista que ya se había iniciado antes
}

foreach (Estudiante estudiante in estudiantes) // Se muestran los estudiantes en consola
{
    Console.WriteLine($"{estudiante.Id} - {estudiante.Nombre} - {estudiante.Carrera}");
}

JsonSerializerOptions opciones = new JsonSerializerOptions // Aquí se convierte la lista a JSON
{
    WriteIndented = true
};

string json = JsonSerializer.Serialize(estudiantes, opciones);

File.WriteAllText("estudiantes.json", json); // Por último, se guarda el archivo JSON

Console.WriteLine("Archivo estudiantes.json creado correctamente.");