namespace Tp02.Models;

public class Receta
{
    public string NombreCocinero{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string Tipo{get;set;}
    public int Precio{get;set;}
    public int CantPersonas{get;set;}
    public string NombrePlato{get;set;}
    public int Tiempo{get;set;}
    public string Dificultad{get;set;}

    public int CalcularEdad(){
        int edad = DateTime.Today.Year - FechaNacimiento.Year;

        if (FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
        {
            edad--;
        }  
        return edad;  
    }

    public void DeterminarPlato(){
        if(Tipo == "Caliente" && Precio <= 3000)
        {
            NombrePlato = "Fideos con manteca";
        }
        if(Tipo == "Caliente" && Precio > 3000 && Precio < 7000)
        {
            NombrePlato = "Arroz con verduras salteadas";
        }
        if(Tipo == "Caliente" && Precio >= 7000)
        {
            NombrePlato = "Pollo al horno con guarnición";
        }
        if(Tipo == "Frio" && Precio <= 3000)
        {
            NombrePlato = "Ensalada simple";
        }
        if(Tipo == "Frio" && Precio > 3000 && Precio < 7000)
        {
            NombrePlato = "Ensalada completa con proteína";
        }
        if(Tipo == "Frio" && Precio >= 7000)
        {
            NombrePlato = "Tabla de fiambres y quesos";
        }
        
    }

    public void CalcularTiempo()
    {
        int tiempo = 0;
        if(CantPersonas<=3){tiempo = 20;}
        if(CantPersonas<=7 && CantPersonas<=4){tiempo = 40;}
        if(CantPersonas>=8){tiempo = 80;}
        if (Tipo == "Frio"){tiempo/=2;}
        Tiempo = tiempo;
    }

    public void DeterminarDificultad()
    {
        if (Precio < 3000 && CantPersonas >= 1 && CantPersonas <= 3) Dificultad = "Principiante";
        if (Precio < 3000 && CantPersonas >= 4 && CantPersonas <= 7) Dificultad = "Intermedio";
        if (Precio >= 3000 && Precio <= 7000 && CantPersonas >= 1 && CantPersonas <= 3) Dificultad = "Intermedio";
        if (Precio >= 3000 && Precio <= 7000 && CantPersonas >= 4) Dificultad = "Intermedio";
        if (Precio > 7000 && CantPersonas >= 1 && CantPersonas <= 7) Dificultad = "Intermedio";
        if (Precio > 7000 && CantPersonas >= 8) Dificultad = "Avanzado";
    }

    public string GenerarSaludo()
    {
        int hora = DateTime.Now.Hour;

        if (hora >= 6 && hora < 12)
        {
            return "¡Buenos días!";
        }
        else if (hora >= 12 && hora < 20)
        {
            return "¡Buenas tardes!";
        }
        else
        {
            return "¡Buenas noches!";
        }
    }

    public string GenerarTip()
    {
        int edad = CalcularEdad();

        if (edad < 18)
        {
            return "El contenido no es recomendado para menores de edad.";
        }
        else if (edad >= 60)
        {
            return "¡Recetas especiales para vos! Disfrutá de cocinar con calma y experiencia.";
        }
        else
        {
            return "¡Excelente elección! Seguí explorando nuevas recetas y mejorando tus habilidades.";
        }
    }
}