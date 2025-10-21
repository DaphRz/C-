using Microsoft.Data.SqlClient;

namespace BancoDados2_AutorLivro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conexao = null;

            string URL = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Banco de Dados_AutorLivro\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; // Banco de Dados

            try
            {
                conexao = new SqlConnection(URL);
                conexao.Open();
                Console.WriteLine("Conexão OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Deu Ruim");
            }

            if (conexao != null)
            {
                Autor autor = new Autor("Daphne");
                //Salvar(autor, conexao);

                autor.Id = 1;

                Livro livro = new Livro("POO2", autor); // new();
                Salvar(livro, conexao);

            }

            conexao?.Close();
        }

        private static void Salvar(Autor autor, SqlConnection conexao)
        {
            Console.WriteLine("\n-- Salvando Autor --");

            var Cmd = conexao.CreateCommand();
            Cmd.CommandText = "INSERT INTO Autor (Nome) VALUES (@nome)";
            Cmd.Parameters.Add(new SqlParameter("nome", autor.Nome));

            Cmd.ExecuteNonQuery(); // Qts Linhas Inseridas
        }

        private static void Salvar(Livro livro, SqlConnection conexao)
        {
            Console.WriteLine("\n-- Salvando Livro --");

            var Cmd = conexao.CreateCommand();
            Cmd.CommandText = "INSERT INTO Livro (Titulo) VALUES (@titulo)";
            Cmd.Parameters.Add(new SqlParameter("titulo", livro.Titulo));

            Cmd.ExecuteNonQuery(); // Qts Linhas Inseridas

            AtualizarTableAutor(livro.AutorDoLivro, conexao);
        }

        private static void AtualizarTableAutor(Autor autorDoLivro, SqlConnection conexao)
        {
            var Cmd = conexao.CreateCommand();

            int idLivroRecuperado = 0;

            Cmd.CommandText = "SELECT MAX(Id) FROM Livro";
            var resultado = Cmd.ExecuteReader(); // Trazer Conj de Dados -- Ler o resultado
            resultado.Read();
            idLivroRecuperado = resultado.GetInt32(0); // SELECT

            resultado.Close();

            Cmd.CommandText = "UPDATE Autor SET Livro_idLivro = @idMax WHERE Id = @idAutor";
            Cmd.Parameters.Add(new SqlParameter("idMax", idLivroRecuperado));
            Cmd.Parameters.Add(new SqlParameter("idAutor", autorDoLivro.Id));
            Cmd.ExecuteNonQuery(); // Qts Linhas Inseridas
        }
    }
}
