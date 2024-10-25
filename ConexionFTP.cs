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
        public string VerificarConexion()
        {
            try
            {
                // Configurar las credenciales y el servidor en el cliente FTP
                _ftpClient.Host = _servidor; // Establecer el host (servidor)
                _ftpClient.Credentials = new System.Net.NetworkCredential(_usuario, _contrasena); // Establecer las credenciales

                // Intentar conectar al servidor FTP
                _ftpClient.Connect();

                // Si la conexión es exitosa, devolver "Conectado"
                return "Conectado";
            }
            catch (Exception)
            {
                // Si hay un error en la conexión, devolver "Desconectado"
                return "Desconectado";
            }
            finally
            {
                // Desconectar el cliente después de verificar la conexión
                if (_ftpClient.IsConnected) // Verificar si el cliente está conectado
                {
                    _ftpClient.Disconnect(); // Desconectar
                }
            }
        }
    }

}
