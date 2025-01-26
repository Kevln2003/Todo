using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Logica
{

        internal class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Contraseña { get; set; }
            public string Tipo { get; set; }

            public Usuario(int id, string nombre, string email, string contraseña, string tipo)
            {
                Id = id;
                Nombre = nombre;
                Email = email;
                Contraseña = contraseña;
                Tipo= tipo; 
            }

            // Método para validar credenciales
            public bool ValidarCredenciales(string email, string contraseña, string tipo)
            {
                return Email == email && Contraseña == contraseña && Tipo==tipo;
            }
        }
    
}
