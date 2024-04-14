//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    /*
    Segun el patrón expert la clase a la que hay que asignarle una tarea es a la que tiene todos los datos
    necesarios para realizarla, es decir, el experto en informacion.

    En este caso el experto en informacion para calcular el costo total es Recipe, ya que Step contiene
    la cantidad, el producto(costo unitario) / el equipamento(costo por hora) y el tiempo usado.
    Pero no contiene todos los steps, solo uno.
    
    La clase recipe tiene un array con cada uno de los step, entonces es facil recorrerlos uno a uno,
    sumando el costo por step y luego hacer una suma total.
    */
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double GetProductionCost()
        {
            double costo = 0;
            foreach (Step step in this.steps)
            {
                costo += step.Equipment.HourlyCost * (step.Time/60);
                Console.WriteLine($"{step.Equipment.HourlyCost} * ({step.Time/60})");
                costo += step.Input.UnitCost * step.Quantity;
                Console.WriteLine($"{step.Input.UnitCost} * {step.Quantity}");
            }
            return costo;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total de la receta es de {GetProductionCost()}");
        }
    }
}