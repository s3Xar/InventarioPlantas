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

void leerOpcionUsuario()
{
    int opcionUsuario = 0;
    try
    {
        opcionUsuario = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("La opción seleccionada no es válida. Por favor ingrese el número que corresponda a la opción seleccionada.");
    }

    switch(opcionUsuario)
    {
        case 1: 
        foreach(PlantaExotica planta in inventarioPlantas)
            {
                Console.WriteLine("| Nombre: " + planta.Nombre + " | Precio: $" + planta.Precio + " | Stock: " + planta.Stock + " |");
            }
        break;

        case 2: 
        running = false;
        break;

        case 3:
        Console.WriteLine("Por favor, ingresa el Nombre de la planta que deseas agreagar al inventario.");
        string? nuevoNombre = Console.ReadLine();

        float nuevoPrecio = PedirFloatSeguro("Ahora ingresa el precio de venta.");

        int nuevoStock = PedirIntSeguro("Finalmente, ingresa el número de stock de la nueva planta.");

        PlantaExotica nuevaPlanta = new PlantaExotica(nuevoNombre, nuevoPrecio, nuevoStock);
        inventarioPlantas.Add(nuevaPlanta);

        Console.WriteLine("Planta agregada con éxito.");
        
        break;

        case 4:
        //pendiente
        break;


    }

}

while(running)
{
    Console.WriteLine("[1] Ver inventario.");
    Console.WriteLine("[2] Salir.");
    Console.WriteLine("[3] Agregar planta al inventario.");
    Console.WriteLine("[4] Vender.");
    Console.WriteLine("Por favor seleccione una opción para continuar.");
    leerOpcionUsuario();
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

    public void Vender()
    {
        if (Stock > 0)
        {
            Stock --;
            Console.WriteLine("Venta exitosa de: " + Nombre);
        }
        else
        {
            Console.WriteLine("No hay stock suficiente de " + Nombre);
        }
    }
}



