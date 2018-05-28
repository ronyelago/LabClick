using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Support
{
    public class ImageControl
    {
        public static Image ConvertByteToImage(byte[] photo)
        {
            // Objeto Image que será retornado
            Image newImage;

            // Objeto MemoryStream que receberá em seu construtor o array,
            // a posição inicial e a posição final do array.
            using (MemoryStream ms = new MemoryStream(photo, 0, photo.Length))
            {
                // Lendo o bloco de bytes
                ms.Write(photo, 0, photo.Length);
                // Cria o objeto Image que é inicializado com o método FromStream
                newImage = Image.FromStream(ms, true);
            }

            return newImage;
        }

        // Converte uma imagem em um array de bytes e o retorna
        // Espera uma PictureBox como parâmetro
        public static byte[] ConvertFileToByte(PictureBox pb)
        {
            MemoryStream memory = new MemoryStream();
            pb.Image.Save(memory, ImageFormat.Jpeg);
            return memory.ToArray();
        }

        public static void SelectImage(PictureBox pb)
        {
            // Cria uma janela para selecionar um arquivo
            OpenFileDialog ofd = new OpenFileDialog();

            // Especifica qual o título da janela
            ofd.Title = "Selecionar Imagem";

            // Especifica que somente um arquivo poderá ser selecionado
            ofd.Multiselect = false;

            // Especifica quais os filtros de extensão de arquivos poderão ser exibidos
            ofd.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif";

            // Ação do botão Ok
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // A PictureBox passada como parâmetro recebe a imagem selecionada
                pb.ImageLocation = ofd.FileName;

                // Redimensiona a imagem de acordo com a PictureBox
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
