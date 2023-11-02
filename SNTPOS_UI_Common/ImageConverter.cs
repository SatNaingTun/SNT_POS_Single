using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SNTPOS_UI_Common
{
  public static  class ImageConverter
    {

      public static byte[] toByteArray(this Image image)
      {
          MemoryStream imageStream = new MemoryStream();
          image.Save(imageStream,image.RawFormat);
          return imageStream.ToArray();
      }

      public static Image toImage( this byte[] byteArray)
      {
          MemoryStream imageStream = new MemoryStream(byteArray);
          Image image = Image.FromStream(imageStream);
          return image;
      }

      public static bool IsNullOrEmpty(this PictureBox pb)
      {
          return pb == null || pb.Image == null;
      }
    }
}
