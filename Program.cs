using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

List<PlantaExotica> inventarioPlantas = new List<PlantaExotica>();
inventarioPlantas.Add(new PlantaExotica("Monstera", 2500, 5));

bool running = true;
Console.WriteLine("Bienvenido al sistema de ventas de Viveros el Roble");

int PedirIntSeguro(string mensajeInstruccion)
{
    Console.WriteLine(mensajeInstruccion);

    while(true)
    {
        try
        {
            int numeroInt = Convert.ToInt32(Console.ReadLine());
            return numeroInt;
        }
        catch
        {
            Console.WriteLine("Valor ingresado no válido, por favor ingrese un número entero válido.");
        }
    }

        
}

float PedirFloatSeguro(string mensajeInstruccion)
{
    Console.WriteLine(mensajeInstruccion);

    while(true)
    {
        try
        {
            float numeroFloat = float.Parse(Console.ReadLine()!);
            return numeroFloat;
        }
        catch
        {
            Console.WriteLine("Valor ingresado no válido, por favor ingrese un número válido (use coma "," para decimales).");
        }
    }
}

string PedirTextoSeguro(string mensajeInstruccion)
{
    Console.WriteLine(mensajeInstruccion);

    while (true)
    {
        try
        {
            string? textoString = Console.ReadLine();
            return textoString;
        }
        catch
        {
            Console.WriteLine("Texto ingresado no válido, por favor ingresa el nombre de la planta tal y como se muestra en el inventario.");
        }
    }
}

int PedirOpcionUsaurioSegura(string mensajeInstruccion)
{
    Console.WriteLine(mensajeInstruccion);

    while (true)
    {
        try
        {
            int opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }
        catch
        {
            Console.WriteLine("La opción seleccionada no es válida. Por favor ingrese el número que corresponda a la opción seleccionada.");
        }
    }
}

void menuSwitch()
{
    int opcionUsuario = PedirOpcionUsaurioSegura("Por favor seleccione una opción para continuar.");
    switch(opcionUsuario)
    {
        case 1: 
        foreach(PlantaExotica planta in inventarioPlantas)
        {
            Console.WriteLine("| Nombre: " + planta.Nombre + " | Precio: $" + planta.Precio + " | Stock: " + planta.Stock + " |");
        }
        break;

        case 4: 
        running = false;
        break;

        case 3:
        Console.WriteLine("Ingresa el Nombre de la planta que deseas agreagar al inventario.");
        string? nuevoNombre = Console.ReadLine();

        float nuevoPrecio = PedirFloatSeguro("Ahora ingresa el precio de venta.");

        int nuevoStock = PedirIntSeguro("Finalmente, ingresa el número de stock de la nueva planta.");

        PlantaExotica nuevaPlanta = new PlantaExotica(nuevoNombre, nuevoPrecio, nuevoStock);
        inventarioPlantas.Add(nuevaPlanta);

        Console.WriteLine("Planta agregada con éxito.");
            
        break;

        case 2:
        bool vendiendoPlanta = true;
        while(vendiendoPlanta)
        {
            //Imprimir el inventario disponible cuando alguien quiere vender. Me hace sentido de parte del usuario que si quiero vender, no necesite salir y volver a menu para verificar qué plantas existen en el inventario y cuántas quedan.
            foreach(PlantaExotica planta in inventarioPlantas)
            {
                Console.WriteLine("| Nombre: " + planta.Nombre + " | Precio: $" + planta.Precio + " | Stock: " + planta.Stock + " |");
            }
            
            string plantaVenta = PedirTextoSeguro("Ingresa el nombre de la planta que quieres vender.");

            bool plantaEncontrada = false;

            foreach(PlantaExotica planta in inventarioPlantas)
            {
                if (planta.Nombre == plantaVenta)
                {
                        plantaEncontrada = true;
                        int cantidadVenta = PedirIntSeguro("Ingresa el número de plantas que deseas vender.");
                        planta.Vender(cantidadVenta);
                        break;
                }
            }

            if (plantaEncontrada == false)
                {
                    Console.WriteLine("Planta no encontrada en el inventario o no hay stock de la planta seleccionada.");
                }
            vendiendoPlanta = false;

        }
        break;

    }

}

while(running)
{
    Console.WriteLine("[1] Ver inventario.");
    Console.WriteLine("[2] Vender.");
    Console.WriteLine("[3] Agregar planta al inventario.");
    Console.WriteLine("[4] Salir.");
    
    menuSwitch();
}


public class PlantaExotica
{
    public string Nombre{get; set;}
    private float precio;

    public float Precio
    {
        get {return precio;}
        set
        {
            if (value < 0)
            {
                precio = 0;
            }
            else
            {
               precio = value; 
            }
        }
    }

    private int stock;

    public int Stock
    {
        get{return stock;}
        set
        {
            if (value <0)
            {
                stock = 0;
            }
            else
            {
                stock = value;
            }
        }
    }
    public PlantaExotica(string nombrePlanta, float precioPlanta, int stockPlanta)
    {
        Nombre = nombrePlanta; 
        Precio = precioPlanta;
        Stock = stockPlanta;
    }

    public void Vender(int cantidad)
    {
        if (Stock >= cantidad)
        {
            Stock -= cantidad;
            Console.WriteLine("Se han vendido " + cantidad + " de " + Nombre +".");
        }
        else if (Stock < cantidad && Stock > 0)
        {
            Console.WriteLine("Solo quedan " + Stock + " unidades disponibles");
        }
        else
        {
            Console.WriteLine("No hay unidades disponibles, reposición necesaria.");
        }
    }
}



