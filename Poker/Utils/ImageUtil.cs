

using System.Drawing;

namespace Poker
{
    class ImageUtil
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }


        public static Image resizeImage(Image imgToResize, int width, int height)
        {
            return resizeImage(imgToResize, new Size(width, height));
        }
    }
}
