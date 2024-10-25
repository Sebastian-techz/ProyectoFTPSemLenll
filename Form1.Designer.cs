namespace ProyectoFTPSemLenll
{
    using FluentFTP;
    using System;
    using System.IO;
    using System.Windows.Forms;
    public partial class MainForm : Form
    {
        private FtpClient _ftpClient; // Cliente FTP
        private string _archivoSeleccionado; // Ruta completa del archivo seleccionado

        public MainForm()
        {
            InitializeComponent();
            // Inicialmente ocultar los componentes del módulo de carga de archivos
        }


        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblEstadoConexion;
        private TextBox txtServidor;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnConectar;
        private Button btnCargarArchivo;
        private Label lblSeleccionarArchivoEstado;
        private Button btnDescargarArchivo;
        private ListBox lstArchivosServidor;
        private ProgressBar progressBar;
        private Button btnEliminarArchivo;
    }
}

