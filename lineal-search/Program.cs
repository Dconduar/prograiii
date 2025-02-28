using System;
using System.Linq;

class Program
{
    // Método de búsqueda lineal
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                return i; // Retorna la posición si encuentra el elemento
            }
        }
        return -1; // Retorna -1 si no lo encuentra
    }

    // Método de búsqueda binaria (requiere un arreglo ordenado)
    static int BinarySearch(int[] arr, int x)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == x)
                return mid; // Elemento encontrado

            if (arr[mid] < x)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1; // Elemento no encontrado
    }

    // Ordenamiento por Inserción
    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    // Ordenamiento Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Intercambiar elementos
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("=== Programa de Ordenamiento y Búsqueda ===");

        // Solicitar los elementos del arreglo
        Console.Write("Ingrese los elementos del arreglo separados por espacios: ");
        string? input = Console.ReadLine();
        int[] arr = (input ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

        if (arr.Length == 0)
        {
            Console.WriteLine("El arreglo está vacío. Intente nuevamente.");
            return;
        }

        // Menú de selección de ordenamiento
        Console.WriteLine("\nSeleccione el método de ordenamiento:");
        Console.WriteLine("1. Ordenamiento por Inserción");
        Console.WriteLine("2. Ordenamiento Bubble Sort");
        Console.Write("Opción: ");
        string? optionSort = Console.ReadLine();

        // Aplicar el método de ordenamiento seleccionado
        switch (optionSort)
        {
            case "1":
                InsertionSort(arr);
                Console.WriteLine("\nArreglo ordenado con Inserción: " + string.Join(" ", arr));
                break;
            case "2":
                BubbleSort(arr);
                Console.WriteLine("\nArreglo ordenado con Bubble Sort: " + string.Join(" ", arr));
                break;
            default:
                Console.WriteLine("Opción inválida. Saliendo del programa.");
                return;
        }

        // Solicitar el número a buscar
        Console.Write("\nIngrese el número que desea buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Entrada inválida. Debe ingresar un número.");
            return;
        }

        // Menú de selección de búsqueda
        Console.WriteLine("\nSeleccione el método de búsqueda:");
        Console.WriteLine("1. Búsqueda Lineal");
        Console.WriteLine("2. Búsqueda Binaria (requiere ordenamiento)");
        Console.Write("Opción: ");
        string? optionSearch = Console.ReadLine();

        int result = -1;

        // Aplicar el método de búsqueda seleccionado
        switch (optionSearch)
        {
            case "1":
                result = LinearSearch(arr, x);
                Console.WriteLine("\nMétodo utilizado: Búsqueda Lineal");
                break;
            case "2":
                result = BinarySearch(arr, x);
                Console.WriteLine("\nMétodo utilizado: Búsqueda Binaria");
                break;
            default:
                Console.WriteLine("Opción inválida. Saliendo del programa.");
                return;
        }

        // Mostrar el resultado
        if (result != -1)
        {
            Console.WriteLine($"El número {x} se encuentra en la posición {result}.");
        }
        else
        {
            Console.WriteLine($"El número {x} no está en el arreglo.");
        }
    }
}
