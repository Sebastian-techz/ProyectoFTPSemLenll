using FluentFTP;
using System;

namespace ProyectoFTPSemLenll
{
    public class ConexionFTP
    {
        private FtpClient _ftpClient; // Cliente FTP de FluentFTP para realizar conexiones
        private string _servidor; // Dirección del servidor FTP
        private string _usuario; // Nombre de usuario para la autenticación
        private string _contrasena; // Contraseña para la autenticación

        // Constructor que inicializa las credenciales y el servidor
        public ConexionFTP(string servidor, string usuario, string contrasena)
        {
            _servidor = servidor; // Asignar la dirección del servidor
            _usuario = usuario; // Asignar el nombre de usuario
            _contrasena = contrasena; // Asignar la contraseña
            _ftpClient = new FtpClient(); // Crear una nueva instancia del cliente FTP
        }

        // Método para verificar la conexión al servidor FTP
      
    }

}
