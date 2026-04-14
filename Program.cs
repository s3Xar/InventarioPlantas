using System;
using System.Collections.Generic;

public class PlantaExotica
{
    private string nombre;
    private float precio;
    private int stock;
    public PlantaExotica(string nombrePlanta, float precioPlanta, int stockPlanta)
    {
        nombre = nombrePlanta; 
        precio = precioPlanta;
        stock = stockPlanta;
    }
    //falta agregar el get/set para que el número no sea negativo en precio y stock.
    public void Vender()
    {
        if (stock > 0)
        {
            stock --;
            Console.WriteLine("Venta exitosa.");
        }
        else
        {
            Console.WriteLine("No hay stock suficiente.");
        }
    }
}
